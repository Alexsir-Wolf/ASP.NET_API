using ASP.NET_API.Model;
using System.Collections.Generic;

namespace ASP.NET_API.Servicos.Implementacoes
{
    public class ImplementacaoServicosPessoa : IPessoaService
    {
        public Pessoa Criar(Pessoa pessoa)
        {

            return pessoa;
        }

        public void Deletar(long id)
        {
            
        }

        public Pessoa ProcurarPorID(long id)
        {
            return new Pessoa
            {
                Id = 1,
                Nome = "Alex",
                SobreNome = "Freitas",
                Endereco = "Rua Dois",
                Genero = "Masculino"
            };
        }

        public List<Pessoa> ProcurarTodos()
        {
            List<Pessoa> pessoas = new List<Pessoa>();
            for (int i = 0; i < 8; i++)
            {
                Pessoa pessoa = new Pessoa
                {
                    Id = 1,
                    Nome = "Alex",
                    SobreNome = "Freitas",
                    Endereco = "Rua Dois",
                    Genero = "Masculino"
                };
                pessoas.Add(pessoa);
            }
            return pessoas;

        }

        public Pessoa Update(Pessoa pessoa)
        {
            return pessoa;
        }
    }
}
