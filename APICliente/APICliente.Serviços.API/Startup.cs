using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using APICliente.Infra.CrossCutting.IoC;
using APICliente.Infra.Data.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

namespace APICliente.Serviços.API
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

            services.AddDbContext<APIClienteContext>(options =>
               options.UseSqlServer(
                   Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Transient
                   );

            InjetorDependencia.Registrar(services);

            //services.AddSwaggerGen(options =>
            //{
            //    options.ExampleFilters();
            //    options.EnableAnnotations();
            //    options.SwaggerDoc(
            //        "v1",
            //        new OpenApiInfo
            //        {
            //            Version = "v1",
            //            Title = "API Cliente",
            //            Description = "Api de Clientes e Endereços"
            //        });

            //    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            //    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            //    options.IncludeXmlComments(xmlPath);
            //});

            // services.AddSwaggerExamplesFromAssemblies(Assembly.GetEntryAssembly());

            services.AddSwaggerGen(c => {

                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Comentários",
                        Version = "v3.0",
                        Description = "Exemplo de API REST criada com o ASP.NET Core 3.0 para cadastramento de comentários",
                        Contact = new OpenApiContact
                        {
                            Name = "Renato Groffe",
                            Url = new Uri("https://github.com/renatogroffe")
                        }
                    });
            });

        }

            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Indicadores Econômicos V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
