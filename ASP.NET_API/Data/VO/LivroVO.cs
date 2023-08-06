using ASP.NET_API.Hypermedia;
using ASP.NET_API.Hypermedia.Abstract;
using System;
using System.Collections.Generic;

namespace ASP.NET_API.Model
{
	public class LivroVO : ISuportHyperMedia
	{
        public long Id { get; set; }
        public string Titulo { get; set; }
		public string Autor { get; set; }
		public decimal Preco { get; set; }
		public DateTime DataLancamento { get; set; }
		public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
	}
}
