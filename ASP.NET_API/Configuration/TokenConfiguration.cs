namespace ASP.NET_API.Configuration
{
	public class TokenConfiguration
	{
        public string Audiencia { get; set; }
        public string Emissor { get; set; }
        public string Segredo { get; set; }
        public int Minutos { get; set; }
        public int DiasParaExpirar { get; set; }
    }
}
