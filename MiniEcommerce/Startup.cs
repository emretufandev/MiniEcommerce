using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MiniEcommerce.Business.DependencyResolvers;
using MiniEcommerce.UI.Middlewares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniEcommerce
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
            services.AddDependencyResolvers(Configuration);
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

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseMiddleware<ExceptionMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "adminRegister",
                    pattern: "admin/register",
                    defaults: new { controller = "Account", action = "Register" }
                );

                endpoints.MapControllerRoute(
                    name: "adminLogin",
                    pattern: "admin/login",
                    defaults: new { controller = "Account", action = "Login" }
                );

                endpoints.MapControllerRoute(
                    name: "adminProductList",
                    pattern: "admin/products",
                    defaults: new { controller = "ProductAdmin", action = "Index" }
                );

                endpoints.MapControllerRoute(
                    name: "adminProductCreate",
                    pattern: "admin/products/create",
                    defaults: new { controller = "ProductAdmin", action = "Create" }
                );

                endpoints.MapControllerRoute(
                    name: "adminProductEdit",
                    pattern: "admin/products/{id}",
                    defaults: new { controller = "ProductAdmin", action = "Edit" }
                );

                endpoints.MapControllerRoute(
                    name: "adminProductDelete",
                    pattern: "admin/products/delete/{id}",
                    defaults: new { controller = "ProductAdmin", action = "Delete" }
                );
                endpoints.MapControllerRoute(
                    name: "productDetail",
                    pattern: "products/detail/{id}",
                    defaults: new { controller = "Product", action = "Detail" }
                );
            });
        }
    }
}
