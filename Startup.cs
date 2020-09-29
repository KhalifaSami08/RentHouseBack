using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend_RentHouse_Khalifa_Sami.Data;
using Backend_RentHouse_Khalifa_Sami.Model.Property;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Backend_RentHouse_Khalifa_Sami
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
            services.AddControllers();

            // la chaine de co se trouve dans le fichier appsettings.json
            services.AddDbContext<MyDbContext>(opt =>
                opt.UseSqlServer(Configuration.GetConnectionString("PropertyConnection"))
            );

            // lier l'interface a la bdd
            services.AddScoped<IPropertyRepo,SqlPropertyRepo>();

            services
                .AddControllersWithViews()
                .AddNewtonsoftJson();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
