using ASP.NET_API.Model;
using ASP.NET_API.Model.Base;
using System.Collections.Generic;

namespace ASP.NET_API.Repository
{
	public interface IRepository<T> where T : BaseEntity
	{
        T Criar(T item);
        T ProcurarPorID(long id);
        List<T> ProcurarTodos();
        T Update(T item);
        void Deletar(long id);
        bool ExistePessoa(long id);
    }
}
