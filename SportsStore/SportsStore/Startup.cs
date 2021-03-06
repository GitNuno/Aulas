﻿

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SportsStore.Models;
using Microsoft.EntityFrameworkCore;

namespace SportsStore
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

            //  *** se quiser mudar repositorio...
            //- assim não preciso de mudar mais nada que nao seja FakeProductRepository
            // services.AddTransient<IProductRepository, FakeProductRepository>(); // mudado!!

            // serviço 
            // se fizesse com classe em vez de interface: IProductRepository ...
            services.AddTransient<IProductRepository, EFProductRepository>();

            // configurar EF
            services.AddDbContext<ApplicationDbContext>(
              options => options.UseSqlServer(
                  // vou por nome da string connection do appsettings.jason
                  Configuration.GetConnectionString("ConnectionStringSportsStore")
              )
          );

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            // Original
            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller=Home}/{action=Index}/{id?}");
            //});

            // mudar pagina de abertura por defeito
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Products}/{action=List}/{id?}");
            });


            // popular B:D.
            SeedData.EnsurePopulated(app.ApplicationServices);
        }
    }
}
