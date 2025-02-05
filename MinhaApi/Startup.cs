using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MinhaApi.Repositories.Interfaces;
using MinhaApi.Repositories;
using MinhaApi.Services.Interfaces;
using MinhaApi.Services;
using Microsoft.EntityFrameworkCore;

namespace MinhaApi
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MeuDbContext>(options =>
                options.UseSqlServer("sua_string_de_conexao_aqui"));

            services.AddScoped<IMeuRepositorio, MeuRepositorio>();
            services.AddScoped<IMeuServico, MeuServico>();

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}