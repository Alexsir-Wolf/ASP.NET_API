using ASP.NET_API.Data.Converter.Implementations;
using ASP.NET_API.Model;
using ASP.NET_API.Repository;
using System.Collections.Generic;

namespace ASP.NET_API.Business.Implementacoes
{
	public class LivroBusinessImplementation : ILivroBusiness
    {
        private readonly IRepository<Livro> _repository;
		private readonly LivroConverter _converter;

		public LivroBusinessImplementation(IRepository<Livro> repository) 
        {
            _repository = repository;
            _converter = new LivroConverter();
        }

        public LivroVO Criar(LivroVO livro)
        {
			//parse de VO para LIVRO, persiste em CRIAR e converte para VO e retorna
			var livroEntity = _converter.Parse(livro);
			livroEntity = _repository.Criar(livroEntity);
			return _converter.Parse(livroEntity);
		}

        public LivroVO ProcurarPorID(long id)
        {
			return _converter.Parse(_repository.ProcurarPorID(id));
		}

        public List<LivroVO> ProcurarTodos()
        {
			return _converter.Parse(_repository.ProcurarTodos());
		}

        public LivroVO Update(LivroVO livro)
        {
			//parse de VO para LIVRO, persiste em UPDATE e converte para VO e retorna
			var livroEntity = _converter.Parse(livro);
			livroEntity = _repository.Update(livroEntity);
			return _converter.Parse(livroEntity);
		}

		public void Deletar(long id)
		{
            _repository.Deletar(id);
		}
    }
}
