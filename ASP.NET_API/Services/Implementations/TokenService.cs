using ASP.NET_API.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace ASP.NET_API.Services.Implementations
{
	public class TokenService : ITokenService
	{
		private TokenConfiguration _tokenConfiguration;

		public TokenService(TokenConfiguration tokenConfiguration)
		{
			_tokenConfiguration = tokenConfiguration;
		}

		public string GerarTokenAcesso(IEnumerable<Claim> claims)
		{
			var segredoKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenConfiguration.Segredo));
			var credenciaisEntrada = new SigningCredentials(segredoKey, SecurityAlgorithms.HmacSha256);

			var opcoes = new JwtSecurityToken(
				issuer: _tokenConfiguration.Emissor,
				audience: _tokenConfiguration.Audiencia,
				claims: claims,
				expires: DateTime.Now.AddMinutes(_tokenConfiguration.Minutos),
				signingCredentials: credenciaisEntrada
				);
			return new JwtSecurityTokenHandler().WriteToken(opcoes);
		}
		public string GerarRefreshToken()
		{
			var numeroRandom = new byte[32];
			using (var random = RandomNumberGenerator.Create())
			{
				random.GetBytes(numeroRandom);
				return Convert.ToBase64String(numeroRandom);
			}
		}

		public ClaimsPrincipal PrincipalTokemExpirado(string token)
		{
			var paramValidacaoToken = new TokenValidationParameters
			{
				ValidateAudience = false,
				ValidateIssuer = false,
				ValidateIssuerSigningKey = true,
				IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenConfiguration.Segredo)),
				ValidateLifetime = false,
			};
			var tokenHandler = new JwtSecurityTokenHandler();
			SecurityToken securityToken;

			var principal = tokenHandler.ValidateToken(token, paramValidacaoToken, out securityToken);
			var jwtToken = securityToken as JwtSecurityToken;

			if (jwtToken != null || jwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCulture))
				throw new SecurityTokenException("Token Inválido!");
			return null;
		}
	}
}
