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
using Serilog;
using System;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using ASP.NET_API.Repository.Generic;
using System.Net.Http.Headers;
using ASP.NET_API.Hypermedia.Filters;
using ASP.NET_API.Hypermedia.Enricher;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Rewrite;

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

            //configura��es de log
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //conex�o DB
            var conexao = Configuration["ConnectionStrings:SQLServerConnection"];
            services.AddDbContext<SQLServerContext>(options => options.UseSqlServer(conexao));

            if (Environment.IsDevelopment())
            {
                MigrateDataBase(conexao);
            }

            //Add services sainda em XML ou JSON
            services.AddMvc(options =>
            {
                options.RespectBrowserAcceptHeader = true;
                options.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("application/xml").ToString());
                options.FormatterMappings.SetMediaTypeMappingForFormat("json", MediaTypeHeaderValue.Parse("application/json").ToString());
            })
            .AddXmlSerializerFormatters();

            //ADD HATEOAS para PESSOA
            var filterOptions = new HyperMediaFilterOptions();
            filterOptions.ContentResponseEnricherList.Add(new PessoaEnricher());
            filterOptions.ContentResponseEnricherList.Add(new LivroEnricher());

            services.AddSingleton(filterOptions);

            //Versionamento API
            services.AddApiVersioning();

            //ADD SWAGGER
            services.AddSwaggerGen(x => {
                x.SwaggerDoc("v1", 
                    new OpenApiInfo
                    {
                        Title = "API REST com ASP.NET Core 5 e Docker",
                        Version = "v1",
                        Description = "API RESTFUL desenvolvida em estudo",
                        Contact = new OpenApiContact 
                        {
                            Name = "Alex Freitas",
                            Email = "freitas.alex.soares@outlook.com",
                            Url = new Uri("https://github.com/Alexsir-Wolf")                       
                        }
                    });
            });

            //inje��o de dependencia
            services.AddScoped<IPessoaBusiness, PessoaBusinessImplementation>();
            services.AddScoped<ILivroBusiness, LivroBusinessImplementation>();
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
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

            app.UseSwagger();
            app.UseSwaggerUI(x=> 
            {
                x.SwaggerEndpoint("/swagger/v1/swagger.json", "API REST com ASP.NET Core 5 e Docker");
            });

            var option = new RewriteOptions();
            option.AddRedirect("^$", "swagger");
            app.UseRewriter(option);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllerRoute("DefaultApi", "{controller=values}/{id?}");
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
