using ASP.NET_API.Model;
using ASP.NET_API.Model.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ASP.NET_API.Repository.Implementacoes
{
    public class PessoaRepositoryImplementation : IPessoaRepository
    {
        private SQLServerContext _context;

        public PessoaRepositoryImplementation(SQLServerContext context) 
        {
            _context = context;
        }

        public Pessoa Criar(Pessoa pessoa)
        {
            try
            {
                _context.Add(pessoa);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return pessoa;
        }

        public Pessoa ProcurarPorID(long id)
        {
            return _context.Pessoas.SingleOrDefault(x => x.Id.Equals(id));
        }

        public List<Pessoa> ProcurarTodos()
        {
            return _context.Pessoas.ToList();
        }

        public Pessoa Update(Pessoa pessoa)
        {
            if (!ExistePessoa(pessoa.Id))            
                return new Pessoa();

            var result = _context.Pessoas.SingleOrDefault(x => x.Id.Equals(pessoa.Id));

            if (result != null)
            {
				try
				{
                    _context.Entry(result).CurrentValues.SetValues(pessoa);
                    _context.SaveChanges();
				}
				catch (Exception)
				{
					throw;
				}
			}
            return pessoa;
        }

		public void Deletar(long id)
		{
			var result = _context.Pessoas.SingleOrDefault(x => x.Id.Equals(id));
			if (result != null)
			{
				try
				{
					_context.Pessoas.Remove(result);
					_context.SaveChanges();
				}
				catch (Exception)
				{
					throw;
				}
			}
		}

		public bool ExistePessoa(long id) 
        {
            return _context.Pessoas.Any(x => x.Id.Equals(id));
        }
    }
}
