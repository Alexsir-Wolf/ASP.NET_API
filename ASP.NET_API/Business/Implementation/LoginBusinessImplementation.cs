using ASP.NET_API.Configuration;
using ASP.NET_API.Data.VO;
using ASP.NET_API.Repository;
using ASP.NET_API.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ASP.NET_API.Business.Implementation
{
	public class LoginBusinessImplementation : ILoginBusiness
	{
		private const string DATE_FORMAT = "yyyy-MM-dd HH:mm:ss";
		private TokenConfiguration _configuracao;
		private IUsuarioRepository _usuarioRepository;
		private readonly ITokenService _tokenService;

		public LoginBusinessImplementation(TokenConfiguration configuracao, IUsuarioRepository usuarioRepository, ITokenService tokenService)
		{
			_configuracao = configuracao;
			_usuarioRepository = usuarioRepository;
			_tokenService = tokenService;
		}

		public TokenVO ValidarCredencial(UsuarioVO credenciaisUsuario)
		{
			var usuario = _usuarioRepository.ValidarCredencial(credenciaisUsuario);
			if (usuario == null)
				return null;
			var claims = new List<Claim>
			{
				//estudar sobre clamis
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
				new Claim(JwtRegisteredClaimNames.UniqueName, usuario.NomeUsuario),
			};

			var tokenAcesso = _tokenService.GerarTokenAcesso(claims);
			var refreshToken = _tokenService.GerarRefreshToken();

			usuario.RefreshToken = refreshToken;
			usuario.RefreshTokenExpiracao = DateTime.Now.AddDays(_configuracao.DiasParaExpirar);

			_usuarioRepository.UpdateUsuario(usuario);

			DateTime dataCriacao = DateTime.Now;
			DateTime dataExpiracao = dataCriacao.AddMinutes(_configuracao.Minutos);

			return new TokenVO(true, dataCriacao.ToString(DATE_FORMAT), dataExpiracao.ToString(DATE_FORMAT), tokenAcesso, refreshToken);
		}
	}
}
