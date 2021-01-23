using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Asp.NetCore_samples
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
           

            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Hello from Run middleware 1      ");
            //    await next();
            //});
            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Hello from Run middleware 2      ");
            //    await next();
            //});
            //app.Use(async (context, next) =>
            //{
            //    throw new Exception("Exception!");
            //    await CustomMiddleware.UserMiddleware(context);
            //});

            app.Run(async (context) =>
            {
                throw new Exception("Some error processing the request");
                await context.Response.WriteAsync("Hello World!");
            });

        }
    }

    public class CustomMiddleware
    {
        public static Task UserMiddleware(HttpContext context)
        {
            // Add logic for custom middleware
            return context.Response.WriteAsync("Hello from custom middleware");
        }
    }
}