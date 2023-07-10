using ASP.NET_API.Model.Contexto;
using ASP.NET_API.Business;
using ASP.NET_API.Business.Implementacoes;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ASP.NET_API.Repository;
using ASP.NET_API.Repository.Implementacoes;
using Serilog;
using System;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace ASP.NET_API
{
	public class Startup
    {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;

            //configurações de log
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //conexão DB
            var conexao = Configuration["ConnectionStrings:SQLServerConnection"];
            services.AddDbContext<SQLServerContext>(options => options.UseSqlServer(conexao));

            if (Environment.IsDevelopment())
            {
                MigrateDataBase(conexao);
            }

            //Versionamento API
            services.AddApiVersioning();

            //injeção de dependencia
            services.AddScoped<IPessoaBusiness, PessoaBusinessImplementation>();
            services.AddScoped<IPessoaRepository, PessoaRepositoryImplementation>();
            services.AddScoped<ILivroBusiness, LivroBusinessImplementation>();
            services.AddScoped<ILivroRepository, LivroRepositoryImplementation>();
        }

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

		private void MigrateDataBase(string conexao)
		{
            try
            {
                var evolveConexao = new SqlConnection(conexao);
                var evolve = new Evolve.Evolve(evolveConexao, msg => Log.Information(msg))
                {
                    Locations = new List<string> { "db/migrations", "db/dataset" },
                    IsEraseDisabled = true,
                };
                evolve.Migrate();
            }
            catch (Exception ex)
            {
                Log.Error("Falha na Migration da DataBase", ex);
                throw;
            }
		}
	}
}
