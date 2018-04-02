using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using firstApp.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace firstApp
{
    public class StartupMvc
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //Register Interface and Implementations Here
            services.AddSingleton<IGreetings,Greetings>();
            services.AddScoped<IRestaurantRepository, InMemoryRestaurantRepository>();
            services.AddMvc();
            
        }

        public void Configure(IApplicationBuilder app, 
                            IHostingEnvironment env, 
                            IGreetings greetings,
                            ILogger<StartupMvc> logger)
        {
            //*** Sequence is important ***

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Get Current environment
            var environment = env.EnvironmentName;

            app.UseStaticFiles();
            // app.UseMvcWithDefaultRoute();
            app.UseMvc(ConfigureRoutes);

            app.Run(async (context) =>
            {
                // throw new Exception("Error");

                var greeting = greetings.GetGreetings();
                context.Response.ContentType = "text/plain";
                // await context.Response.WriteAsync($"{greeting} : {environment}");
                await context.Response.WriteAsync($"Page Not Found");
            });
        }

        private void ConfigureRoutes(IRouteBuilder routeBuilder)
        {
            // /home/index
            //if we do not specify any default values it wont load home and index action 
            //? means its optional
            routeBuilder.MapRoute("Default",
            // "{controller}/{action}/{id?}");
            "{controller=Home}/{action=Index}/{id?}");
        }
    }

}
