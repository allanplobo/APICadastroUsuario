
using CadastroUsuario.Business.Servicos;
using CadastroUsuario.Domain.Contratos.Repositorios;
using CadastroUsuario.Domain.Contratos.Servicos;
using CadastroUsuario.Domain.Contratos.Uow;
using CadastroUsuario.Infra.Conexoes;
using CadastroUsuario.Infra.Repositorios;
using CadastroUsuario.Infra.Uow;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CadastroUsuario
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CadastroUsuarioSqliteDbContext>(opts =>
                opts.UseSqlite("Data Source=cadastroUsuario.db", 
                sqlite => sqlite.MigrationsAssembly("CadastroUsuario.Infra")));

            services.AddMvcCore((opts) =>
            {
                opts.EnableEndpointRouting = false;
            });

            services.AddScoped<IPerfilRepositorio, PerfilRepositorio>();
            services.AddScoped<IPerfilServico, PerfilServico>();
            services.AddScoped<IUow, UnidadeTrabalho>();

            services.AddCors((e) =>
                e.AddPolicy("Dev", op => op
                .AllowAnyOrigin()
                .AllowAnyMethod()));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseCors("Dev");
            }

            app.UseMvc();
        }
    }
}
