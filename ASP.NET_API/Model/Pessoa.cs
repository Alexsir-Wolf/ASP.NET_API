using ASP.NET_API.Model.Base;
using System;

namespace ASP.NET_API.Model
{
    public class Pessoa : BaseEntity
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Endereco { get; set; }
        public string Genero { get; set; }
        public string Email { get; set; }
		public int? Idade { get; set; }
    }
}
