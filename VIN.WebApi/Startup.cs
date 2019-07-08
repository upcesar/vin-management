using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using VIN.Application.Automapper;
using VIN.Application.Interfaces;
using VIN.Application.Services;
using VIN.Domain.Interfaces;
using VIN.Infra.Context;
using VIN.Infra.Data.Context.Db;
using VIN.Infra.Data.Context.Interfaces;
using VIN.Infra.Data.Repository.DB;
using VIN_Management.Configuration;

namespace VIN_Management
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
            
            // Register the Swagger generator, defining one or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = $"{AppDomain.CurrentDomain.FriendlyName}", Version = "1.0" });

                var secReqs = new Dictionary<string, IEnumerable<string>> { { "D-Authorization", Enumerable.Empty<string>() }, };
                c.AddSecurityDefinition("D-Authorization", new ApiKeyScheme { In = "header", Description = "Insira o token do autenticador", Name = "D-Authorization", Type = "apiKey" });
                c.AddSecurityRequirement(secReqs);

                var xmlDocumentationPath = Path.Combine(AppContext.BaseDirectory, $"{AppDomain.CurrentDomain.FriendlyName}.xml");
                c.IncludeXmlComments(xmlDocumentationPath);
            });

            services.AddResponseCompression(options =>
            {
                options.Providers.Add<GzipCompressionProvider>();
                options.EnableForHttps = true;
            });

            services.AddTransient<IVehiclesService, VehiclesService>()
                    .AddScoped<IDbContext, SqlServerContext>()
                    .AddScoped<IUnitOfWork, UnitOfWork>()
                    .AddTransient<IVehiclesRepository, VehiclesRepository>()
                    .AddAutoMapperSetup<AutoMapperConfig>();
                    
            
            services.AddMvc()
                    .AddJsonOptions(opt =>
                    {
                        opt.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                        opt.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                    })
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", $"{AppDomain.CurrentDomain.FriendlyName}");
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
