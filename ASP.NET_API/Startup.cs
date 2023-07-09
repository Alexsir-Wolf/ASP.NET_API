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

namespace ASP.NET_API
{
	public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //conexão DB
            var conexao = Configuration["ConnectionStrings:SQLServerConnection"];
            services.AddDbContext<SQLServerContext>(options => options.UseSqlServer(conexao));

            //Versionamento API
            services.AddApiVersioning();

            //injeção de dependencia
            services.AddScoped<IPessoaBusiness, PessoaBusinessImplementation>();
            services.AddScoped<IPessoaRepository, PessoaRepositoryImplementation>();
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
    }
}
