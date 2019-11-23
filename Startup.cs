using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MyCourse
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //da dichiarare per la route di default sotto
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //middleware per mostrare una pagina informativa se c'è un errore
                //vanno messi in ordine
                //in produzione non passeremo da qui
                app.UseDeveloperExceptionPage();
            }

            //middleware file statici
            app.UseStaticFiles();

            app.UseRouting();

            //app.UseEndpoints(endpoints =>
            //{
                //secondo middleware
                //endpoints.MapGet("/", async context =>
                //{
                //    string nome = context.Request.Query["nome"];
                //    await context.Response.WriteAsync($"Hello {nome.ToUpper()}!");

                //});
            //});

            //middleware di routing
            //app.UseMvcWithDefaultRoute();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
