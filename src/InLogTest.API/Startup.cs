using System;
using InLogTest.CrossCutting.IoC;
using InLogTest.Repository;
using InLogTest.Repository.Contexts;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;

namespace InLogTest.API
{
    public class Startup
    {
        private readonly IConfigurationRoot configuration;
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            configuration = builder.Build();

            DatabaseSetting.ConnectionString = configuration.GetConnectionString("DefaultConnection");
            APISettings.Title = configuration["Application"];
            APISettings.Version = configuration["Version"];
            APISettings.Description = configuration["Description"];
            APISettings.ContactName = configuration["ContactName"];
            APISettings.ContactName = configuration["ContactEmail"];
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddResponseCompression();
            services.AddCors();

            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc(APISettings.Version,
                    new Info
                    {
                        Title = APISettings.Title,
                        Version = APISettings.Version,
                        Description = APISettings.Description,
                        Contact = new Contact
                        {
                            Name = APISettings.ContactName,
                            Email = APISettings.ContactEmail
                        }
                    });
            });

            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddConsole();
                loggingBuilder.AddDebug();
                loggingBuilder.AddConfiguration(configuration.GetSection("Logging"));
                loggingBuilder.AddFile(o =>
                {
                    o.RootPath = AppContext.BaseDirectory;
                    var dateTime = DateTime.Now;
                    o.FallbackFileName = $"log-{dateTime.Year}-{dateTime.Month}-{dateTime.Day}.txt";

                });
            });

            RegisterServices(services);

            services.AddMediatR(typeof(Startup));

            services.AddMvc(options =>
            {
                options.OutputFormatters.Remove(new XmlDataContractSerializerOutputFormatter());
            })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddHealthChecks();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, EntityContext entityContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
                app.UseHttpsRedirection();
            }
            app.UseHealthChecks("/health");

            entityContext.ExecuteMigrate();

            app.UseResponseCompression();
            app.UseSwagger();
            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint($"/swagger/{APISettings.Version}/swagger.json", APISettings.Title);
                x.RoutePrefix = string.Empty;
            });

            app.UseCors(x =>
            {
                x.AllowAnyHeader();
                x.AllowAnyMethod();
                x.AllowAnyOrigin();
            });

            app.UseStaticFiles();
            app.UseMvc();
        }
        private void RegisterServices(IServiceCollection services)
        {
            NativeInjectorBootStrapper.InitialService(services);
        }
    }
}
