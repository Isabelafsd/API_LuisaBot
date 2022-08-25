using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_LuisaBot.Interfaces.Repositories;
using API_LuisaBot.Repositories.ConcreteRepositories;
using API_LuisaBot.Repositories.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.Swagger;

namespace API_LuisaBot
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<AppDbContext>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddTransient<ISugestaoRepository, SugestaoRepository>();
            services.AddTransient<ITemaPerguntaRepository, TemaPerguntaRepository>();
            services.AddTransient<IPerguntaRepositoy, PerguntaRepository>();
            services.AddTransient<ITemaRepository, TemaRepository>();

            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Luisa Bot",
                    Description = "Um exemplo de aplicação ASP.NET Core Web API",
                    Contact = new OpenApiContact
                    {
                        Name = "Isabela Fonseca",
                        Email = "isabelafonsecasd@gmail.com.br"
                    }
                });
            }); 
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
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                    );
            });

            //Ativa o Swagger
            app.UseSwagger();

            // Ativa o Swagger UI
            app.UseSwaggerUI(opt =>
            {
                opt.SwaggerEndpoint("/swagger/v1/swagger.json", "LuisaBot V1");
            });
        }
    }
}
