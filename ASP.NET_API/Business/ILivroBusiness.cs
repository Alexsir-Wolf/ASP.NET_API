using ASP.NET_API.Model;
using System.Collections.Generic;

namespace ASP.NET_API.Business
{
    public interface ILivroBusiness
	{
		LivroVO Criar(LivroVO livro);
		LivroVO ProcurarPorID(long id);
        List<LivroVO> ProcurarTodos();
		LivroVO Update(LivroVO livro);
        void Deletar(long id);
    }
}
