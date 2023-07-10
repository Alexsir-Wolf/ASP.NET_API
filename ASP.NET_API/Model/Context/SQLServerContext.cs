using Microsoft.EntityFrameworkCore;

namespace ASP.NET_API.Model.Contexto
{
	public class SQLServerContext : DbContext
	{
		public SQLServerContext() 
		{
		}
		public SQLServerContext(DbContextOptions<SQLServerContext> options) : base(options)
		{
		}

        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Livro> Livros { get; set; }
    }
}
