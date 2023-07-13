using ASP.NET_API.Data.Converter.Contract;
using ASP.NET_API.Data.VO;
using ASP.NET_API.Model;
using System.Collections.Generic;
using System.Linq;

namespace ASP.NET_API.Data.Converter.Implementations
{
	public class LivroConverter : IParser<LivroVO, Livro>, IParser<Livro, LivroVO>
	{
		public LivroVO Parse(Livro origem)
		{
			if (origem == null)
				return null;
			else
				return new LivroVO
				{
					Id = origem.Id,
					Titulo = origem.Titulo,
					Autor = origem.Autor,
					Preco = origem.Preco,
					DataLancamento = origem.DataLancamento,
				};
		}

		public Livro Parse(LivroVO origem)
		{
			if (origem == null)
				return null;
			else
				return new Livro
				{
					Id = origem.Id,
					Titulo = origem.Titulo,
					Autor = origem.Autor,
					Preco = origem.Preco,
					DataLancamento = origem.DataLancamento,
				};
		}

		public List<LivroVO> Parse(List<Livro> origem)
		{
			if (origem == null)
				return null;
			else
				return origem.Select(item => Parse(item)).ToList();
		}

		public List<Livro> Parse(List<LivroVO> origem)
		{
			if (origem == null)
				return null;
			else
				return origem.Select(item => Parse(item)).ToList();
		}
	}
}
