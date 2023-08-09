namespace ASP.NET_API.Data.VO
{
	public class TokenVO
	{
		public TokenVO(bool autenticado, string criacao, string expirado, string tokenAcesso, string refreshToken)
		{
			Autenticado = autenticado;
			Criacao = criacao;
			Expirado = expirado;
			TokenAcesso = tokenAcesso;
			RefreshToken = refreshToken;
		}

		public bool Autenticado { get; set; }
        public string Criacao { get; set; }
        public string Expirado { get; set; }
        public string TokenAcesso { get; set; }
        public string RefreshToken { get; set; }
    }
}
