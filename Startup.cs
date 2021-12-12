/* Author: Kamrin Aubin
 * Last Modified: December 12, 2021
 * Description: Startup File. Launches when application is first ran.
 * 
 */

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Imports the Models namespace
using NETDLab5.Models;
// Used to help with compatibility issues
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace NETDLab5
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
            services.AddControllersWithViews();
            // Allows for the web application to be backwards compatible with .NET Core 2.1
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // Disables endpoint routing. Issue when upgrading from ASP.NET CORE 2.0 to 3.0
            services.AddMvc(options => options.EnableEndpointRouting = false);

            // Adding a connection
            string connection = @"Server=(localdb)\mssqllocaldb;Database=NETDLab5;Trusted_Connection=True;ConnectRetryCount=0";

            // Adds a Db Context for VideoGameContext
            services.AddDbContext<VideoGameContext>(options => options.UseSqlServer(connection));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
