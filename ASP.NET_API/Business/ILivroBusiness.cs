using ASP.NET_API.Model;
using System.Collections.Generic;

namespace ASP.NET_API.Business
{
    public interface ILivroBusiness
	{
        Livro Criar(Livro livro);
        Livro ProcurarPorID(long id);
        List<Livro> ProcurarTodos();
        Livro Update(Livro livro);
        void Deletar(long id);
    }
}
