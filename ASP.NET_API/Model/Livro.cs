using ASP.NET_API.Model.Base;
using System;

namespace ASP.NET_API.Model
{
	public class Livro : BaseEntity
	{
		public string Titulo { get; set; }
		public string Autor { get; set; }
		public decimal Preco { get; set; }
		public DateTime DataLancamento { get; set; }
	}
}
