using ASP.NET_API.Model;
using System.Collections.Generic;

namespace ASP.NET_API.Repository
{
    public interface IPessoaRepository
	{
        Pessoa Criar(Pessoa pessoa);
        Pessoa ProcurarPorID(long id);
        List<Pessoa> ProcurarTodos();
        Pessoa Update(Pessoa pessoa);
        void Deletar(long id);
        bool ExistePessoa(long id);
    }
}
