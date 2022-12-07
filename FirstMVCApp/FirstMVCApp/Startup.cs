using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FirstMVCApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            /*
             * The following line of code adds all the MVC related services
             * to our project.
             */
            services.AddMvc();

            //Here, we disable endpoint routing. This was an issue when upgrading from ASP.NET CORE 2.0 to ASP.NET Core 3.0
            services.AddMvc(options => options.EnableEndpointRouting = false);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            /*
             * If you recall, in Slide 10 of the Week 8 - MVC Design Pattern slide deck,
             * I said: I will show you how to add the middleware to the request pipeline in one simple
             * line of code. This is how we are achieving that! 
             * The UseMvcWithDefaultRoute installs MVC Middleware with the default Route.
             * In the future, we will create our own routes.
             * Routing is simply taking a look at the request and mapping it to a controller.
             */
            app.UseMvcWithDefaultRoute();

         
        }
    }
}
