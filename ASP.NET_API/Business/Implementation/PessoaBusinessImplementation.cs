using ASP.NET_API.Data.Converter.Implementations;
using ASP.NET_API.Data.VO;
using ASP.NET_API.Model;
using ASP.NET_API.Repository;
using System.Collections.Generic;

namespace ASP.NET_API.Business.Implementacoes
{
	public class PessoaBusinessImplementation : IPessoaBusiness
    {
        private readonly IRepository<Pessoa> _repository;
        private readonly PessoaConverter _converter;

        public PessoaBusinessImplementation(IRepository<Pessoa> repository) 
        {
            _repository = repository;
            _converter = new PessoaConverter();
        }

        public PessoaVO Criar(PessoaVO pessoa)
        {
            //parse de VO para PESSOA, persiste em CRIAR e converte para VO e retorna
            var pessoaEntity = _converter.Parse(pessoa);
            pessoaEntity = _repository.Criar(pessoaEntity);
            return _converter.Parse(pessoaEntity);
        }

        public PessoaVO ProcurarPorID(long id)
        {
            return _converter.Parse(_repository.ProcurarPorID(id));
        }

        public List<PessoaVO> ProcurarTodos()
        {
            return _converter.Parse(_repository.ProcurarTodos());
        }

        public PessoaVO Update(PessoaVO pessoa)
        {
			//parse de VO para PESSOA, persiste em UPDATE e converte para VO e retorna
			var pessoaEntity = _converter.Parse(pessoa);
			pessoaEntity = _repository.Update(pessoaEntity);
			return _converter.Parse(pessoaEntity);
		}

		public void Deletar(long id)
		{
            _repository.Deletar(id);
		}
    }
}
