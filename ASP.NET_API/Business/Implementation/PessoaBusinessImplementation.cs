using ASP.NET_API.Model;
using ASP.NET_API.Model.Contexto;
using ASP.NET_API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ASP.NET_API.Business.Implementacoes
{
    public class PessoaBusinessImplementation : IPessoaBusiness
    {
        private readonly IRepository<Pessoa> _repository;

        public PessoaBusinessImplementation(IRepository<Pessoa> repository) 
        {
            _repository = repository;
        }

        public Pessoa Criar(Pessoa pessoa)
        {
            return _repository.Criar(pessoa);
        }

        public Pessoa ProcurarPorID(long id)
        {
            return _repository.ProcurarPorID(id);
        }

        public List<Pessoa> ProcurarTodos()
        {
            return _repository.ProcurarTodos();
        }

        public Pessoa Update(Pessoa pessoa)
        {
            return _repository.Update(pessoa);
        }

		public void Deletar(long id)
		{
            _repository.Deletar(id);
		}
    }
}
