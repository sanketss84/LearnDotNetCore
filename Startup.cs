using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using firstApp.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

//This code is now not called from Program.cs instead StartupMvc.cs is called.
namespace firstApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //Register Interface and Implementations Here
            services.AddSingleton<IGreetings,Greetings>();
            
        }

        //Currently there are four pieces of middleware
        //IsDevelopment, CustomMiddleware, UseWelcomePage, Greetings
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, 
                            IHostingEnvironment env, 
                            IGreetings greetings,
                            ILogger<Startup> logger)
        {
            //Middleware Configuration goes here
            //*** Sequence is important ***

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //To make sure that index.html is called as default file 
            //we need to have this middleware in place
            //if this is not there then we need to call 
            //sitename.com/index.html always this bypasses that
            // app.UseDefaultFiles();

            //To call static pages we need this middleware
            //This loads pages from wwwroot folder 
            // app.UseStaticFiles();

            //replaces UseDefaultFiles and UseStaticFiles with one call
            app.UseFileServer();

            //Get Current environment
            var environment = env.EnvironmentName;

            //Custom Middleware for path /mym i.e. my middleware :)
            //if url is not /mym then pass along
            // app.Use(next => {
            //     return async context => {
            //         logger.LogInformation("Request Incoming");
            //         if (context.Request.Path.StartsWithSegments("/mym"))
            //         {
            //             await context.Response.WriteAsync("Hit!!");
            //             logger.LogInformation("Response Handled");
            //         }
            //         else
            //         {
            //             await next(context);
            //             logger.LogInformation("Response Outgoing");
            //         }
            //     };
            // });

            //Responds to request whose path would be /wp 
            // app.UseWelcomePage(new WelcomePageOptions{
            //     Path = "/wp"
            // });

            app.Run(async (context) =>
            {
                // throw new Exception("Error");

                var greeting = greetings.GetGreetings();
                await context.Response.WriteAsync($"{greeting} : {environment}");
            });
        }
    }

}
