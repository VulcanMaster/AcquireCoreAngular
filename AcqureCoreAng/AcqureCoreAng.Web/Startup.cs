using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace AcqureCoreAng.Web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
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
