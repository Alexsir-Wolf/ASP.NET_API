using ASP.NET_API.Model.Base;
using ASP.NET_API.Model.Contexto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ASP.NET_API.Repository.Generic
{
	public class GenericRepository<T> : IRepository<T> where T : BaseEntity
	{
		private SQLServerContext _context;
		private DbSet<T> dataset;

        public GenericRepository(SQLServerContext context)
        {
			_context = context;
			dataset = _context.Set<T>();            
        }

        public T Criar(T item)
		{
			try
			{
				dataset.Add(item);
				_context.SaveChanges();
				return item;
			}
			catch (System.Exception)
			{
				throw;
			}
		}

		public void Deletar(long id)
		{
			var result = dataset.SingleOrDefault(x => x.Id.Equals(id));
			if (result != null)
			{
				try
				{
					dataset.Remove(result);
					_context.SaveChanges();
				}
				catch (System.Exception)
				{
					throw;
				}
			}
		}

		public bool ExistePessoa(long id)
		{
			return dataset.Any(x => x.Id.Equals(id));
		}

		public T ProcurarPorID(long id)
		{
			return dataset.SingleOrDefault(x => x.Id.Equals(id));
		}

		public List<T> ProcurarTodos()
		{
			return dataset.ToList();
		}

		public T Update(T item)
		{
			var result = dataset.SingleOrDefault(x => x.Id.Equals(item.Id));
			if (result != null)
			{
				try
				{
					_context.Entry(result).CurrentValues.SetValues(item);
					_context.SaveChanges();
					return result;
				}
				catch (System.Exception)
				{
					throw;
				}
			}
			else			
				return null;			
		}
	}
}
