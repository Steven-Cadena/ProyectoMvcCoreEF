using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProyectoMvcCoreEF.Data;
using ProyectoMvcCoreEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoMvcCoreEF
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
            //pasamos por parametro el nombre de la cadena de appsettings.json
            String cadenaSqlServer = this.Configuration.GetConnectionString("cadenahospitalsql");
            DepartamentosContextSQLServer contextSQL = new DepartamentosContextSQLServer(cadenaSqlServer);
            services.AddTransient<IDepartamentosContext>(z => contextSQL);


            //DEBEMOS RESOLVER LAS DEPENDENCIAS ANTES DE
            //CARGAR LOS CONTROLADORES Y LOS SERVICIOS 
            //services.AddTransient<Coche>();

            //importante poner el nombre la interface y la clase
            //services.AddSingleton<ICoche, Coche>();

            //VAMOS A INSTANCIAR UN OBJETO Y LO ENVIAREMOS CREADO DESDE AQUI
            Deportivo deportivo = new Deportivo();
            deportivo.Marca = "BMW";
            deportivo.Modelo = "A3";
            deportivo.Imagen = "bmw.jpg";
            deportivo.VelocidadMaxima = 360;
            services.AddSingleton<ICoche>(z => deportivo);

            services.AddControllersWithViews();
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
