using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Test2.Models;
using Test2.Services;

namespace Test2
{
    public class Startup
    {
        private readonly IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ProtoContext>(cfg => {
                cfg.UseSqlServer(_config.GetConnectionString("ProtoConnectionString"));
            } );

            services.AddTransient<IMailService, NullMailService>();
            //support for real mail service

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("<html><head></head><body><h6>Hello<il> World!</il></h6></body></html>");
            //});



            // app.UseDefaultFiles();
            if(env.IsDevelopment())
            {
            app.UseDeveloperExceptionPage();

            }

            else
            {
                app.UseExceptionHandler("/error");
            }

            app.UseStaticFiles();
            app.UseNodeModules(env);

            app.UseMvc(cfg=> {
                cfg.MapRoute("Default",
                    "{Controller}/{Action}/{id?}",
                    new { Controller = "App", Action = "Index" });
            });

        }
    }
}
