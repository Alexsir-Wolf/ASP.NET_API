using ASP.NET_API.Data.Converter.Contract;
using ASP.NET_API.Data.VO;
using ASP.NET_API.Model;
using System.Collections.Generic;
using System.Linq;

namespace ASP.NET_API.Data.Converter.Implementations
{
	public class PessoaConverter : IParser<PessoaVO, Pessoa>, IParser<Pessoa, PessoaVO>
	{
		public PessoaVO Parse(Pessoa origem)
		{
			if (origem == null)
				return null;
			else
				return new PessoaVO
				{
					Id = origem.Id,
					Nome = origem.Nome,
					Sobrenome = origem.Sobrenome,
					Genero = origem.Genero,
					Endereco = origem.Endereco,
					Email = origem.Email,
					Idade = origem.Idade,
				};
		}

		public Pessoa Parse(PessoaVO origem)
		{
			if (origem == null)
				return null;
			else
				return new Pessoa
				{
					Id = origem.Id,
					Nome = origem.Nome,
					Sobrenome = origem.Sobrenome,
					Genero = origem.Genero,
					Endereco = origem.Endereco,	
					Email = origem.Email,
					Idade = origem.Idade,
				};			
		}

		public List<PessoaVO> Parse(List<Pessoa> origem)
		{
			if (origem == null)
				return null;
			else
				return origem.Select(item => Parse(item)).ToList();
		}

		public List<Pessoa> Parse(List<PessoaVO> origem)
		{
			if (origem == null)
				return null;
			else
				return origem.Select(item => Parse(item)).ToList();
		}
	}
}
