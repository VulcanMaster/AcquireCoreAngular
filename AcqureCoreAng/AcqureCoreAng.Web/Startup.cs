using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcqureCoreAng.Web.Data;
using AcqureCoreAng.Web.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AcqureCoreAng.Web
{
    public class Startup
    {
        private readonly IConfiguration _config;

        public Startup(IConfiguration config)
        {
            this._config = config;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<AcquireContext>(cfg =>
            //{
            //    _config.GetConnectionString("AcquireConnectionString");
            //    //cfg.UseSqlServer("");
            //});


            //Tell services that we'd like it to use our context.
            services.AddDbContext<AcquireContext>(cfg =>
            {

                cfg.UseSqlServer(_config.GetConnectionString("DutchConnectionString"));


                //if (_env.IsDevelopment())
                //{
                //    cfg.UseSqlite("Data Source=DutchDb");
                //}

                //if (_env.IsProduction())
                //{
                //    //Get the connection string from configuration.
                    
                //}
            });

            services.AddTransient<IMailService, NullMailService>();

            // add suppiort for real email service

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            // old school to separate the development mode from prodction            
            //#if DEBUG
            //            app.UseDeveloperExceptionPage();
            //#endif

            // current community style to separate development environment from others
            // the option about environment type is in project properties, shift `Debug`,
            // the section `Environment variables`, something like `ASPNETCORE_ENVIRONMENT`
            // with the Value `Development`.
            if (env.IsDevelopment()) //  the same: if (env.IsEnvironment("Development"))
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
            }

            //app.UseDefaultFiles();

            app.UseStaticFiles();

            app.UseNodeModules(env); // this line was needed to support the node modules previosly of MVC enabling

            // The lambda expression does mapping for routes
            app.UseMvc(cfg =>
                {
                    // common controller
                    // if the controller with the precisely specified route will be detected
                    // the it will fire, otherwise the configuraion will use controller App
                    // and call the Index action. I.e. all the wrong typed routes will lead to
                    // the App controller.
                    cfg.MapRoute("Default",
                        "/{controller}/{action}/{id?}",
                        new { controller = "App", Action = "Index" });

                });


            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("<html><body><p>Hello from StartUp!</p></body></html>");
            });
        }
    }
}
