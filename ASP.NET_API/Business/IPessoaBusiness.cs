using ASP.NET_API.Data.VO;
using System.Collections.Generic;

namespace ASP.NET_API.Business
{
	public interface IPessoaBusiness
	{
		PessoaVO Criar(PessoaVO pessoa);
		PessoaVO ProcurarPorID(long id);
        List<PessoaVO> ProcurarTodos();
		PessoaVO Update(PessoaVO pessoa);
        void Deletar(long id);
    }
}
