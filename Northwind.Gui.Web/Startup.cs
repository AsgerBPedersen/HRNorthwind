using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.Extensions.DependencyInjection;
using Northwind.DataAcess;
using Northwind.Entities.Models;

namespace Northwind.Gui.Web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddRazorPagesOptions(options =>
            {
                options.Conventions.AddPageRoute("/Ordre/Index", "");
            }).AddMvcOptions(options => {
                options.EnableEndpointRouting = false;
            });
            //services.AddDbContext<NorthwindContext>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<NorthwindContext, NorthwindContext>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
           
               app.UseDeveloperExceptionPage();
                //app.UseExceptionHandler("/Errors/Default");

            app.UseMvcWithDefaultRoute();
            app.UseStaticFiles();
        }
    }
}
