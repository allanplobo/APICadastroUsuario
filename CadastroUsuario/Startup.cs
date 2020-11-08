
using CadastroUsuario.Infra.Conexoes;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;

namespace CadastroUsuario
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CadastroUsuarioSqliteDbContext>(opts =>
                opts.UseSqlite("database=cadastroUsuario.db", sqlite => sqlite.MigrationsAssembly("CadastroUsuario.Infra")));

            services.AddMvcCore((opts) =>
            {
                opts.EnableEndpointRouting = false;
            });

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
