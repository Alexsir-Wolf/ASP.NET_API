using ASP.NET_API.Hypermedia;
using ASP.NET_API.Hypermedia.Abstract;
using System.Collections.Generic;

namespace ASP.NET_API.Data.VO
{
	public class PessoaVO : ISuportHyperMedia
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Endereco { get; set; }
        public string Genero { get; set; }
        public string Email { get; set; }
		public int? Idade { get; set; }
		public List<HyperMediaLink> Links { get ; set ; } = new List<HyperMediaLink>();
	}
}
