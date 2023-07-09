using ASP.NET_API.Model;
using System.Collections.Generic;

namespace ASP.NET_API.Business
{
    public interface IPessoaBusiness
	{
        Pessoa Criar(Pessoa pessoa);
        Pessoa ProcurarPorID(long id);
        List<Pessoa> ProcurarTodos();
        Pessoa Update(Pessoa pessoa);
        void Deletar(long id);
    }
}
