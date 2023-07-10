using ASP.NET_API.Model;
using ASP.NET_API.Model.Contexto;
using ASP.NET_API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ASP.NET_API.Business.Implementacoes
{
    public class LivroBusinessImplementation : ILivroBusiness
    {
        private readonly ILivroRepository _repository;

        public LivroBusinessImplementation(ILivroRepository repository) 
        {
            _repository = repository;
        }

        public Livro Criar(Livro livro)
        {
            return _repository.Criar(livro);
        }

        public Livro ProcurarPorID(long id)
        {
            return _repository.ProcurarPorID(id);
        }

        public List<Livro> ProcurarTodos()
        {
            return _repository.ProcurarTodos();
        }

        public Livro Update(Livro livro)
        {
            return _repository.Update(livro);
        }

		public void Deletar(long id)
		{
            _repository.Deletar(id);
		}
    }
}
