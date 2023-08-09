using System;

namespace ASP.NET_API.Data.VO
{
	public class UsuarioVO
	{
		public long Id { get; set; }
		public string NomeUsuario { get; set; }
		public string Senha { get; set; }
		public string NomeCompleto { get; set; }
		public string RefreshToken { get; set; }
		public DateTime RefreshTokenExpiracao { get; set; }
	}
}
