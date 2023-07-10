using ASP.NET_API.Model;
using ASP.NET_API.Model.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ASP.NET_API.Repository.Implementacoes
{
    public class LivroRepositoryImplementation : ILivroRepository
	{
        private SQLServerContext _context;

        public LivroRepositoryImplementation(SQLServerContext context) 
        {
            _context = context;
        }

        public Livro Criar(Livro livro)
        {
            try
            {
                _context.Add(livro);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return livro;
        }

        public Livro ProcurarPorID(long id)
        {
            return _context.Livros.SingleOrDefault(x => x.Id.Equals(id));
        }

        public List<Livro> ProcurarTodos()
        {
            return _context.Livros.ToList();
        }

        public Livro Update(Livro livro)
        {
            if (!ExisteLivro(livro.Id))            
                return null;

            var result = _context.Livros.SingleOrDefault(x => x.Id.Equals(livro.Id));

            if (result != null)
            {
				try
				{
                    _context.Entry(result).CurrentValues.SetValues(livro);
                    _context.SaveChanges();
				}
				catch (Exception)
				{
					throw;
				}
			}
            return livro;
        }

		public void Deletar(long id)
		{
			var result = _context.Livros.SingleOrDefault(x => x.Id.Equals(id));
			if (result != null)
			{
				try
				{
					_context.Livros.Remove(result);
					_context.SaveChanges();
				}
				catch (Exception)
				{
					throw;
				}
			}
		}

		public bool ExisteLivro(long id) 
        {
            return _context.Livros.Any(y => y.Id.Equals(id));
        }
    }
}
