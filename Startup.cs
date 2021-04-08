using System;
using AutoMapper;
using Backend_RentHouse_Khalifa_Sami.DAL;
using Backend_RentHouse_Khalifa_Sami.DAL.ClientData;
using Backend_RentHouse_Khalifa_Sami.DAL.ContractData;
using Backend_RentHouse_Khalifa_Sami.DAL.PropertyData;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Backend_RentHouse_Khalifa_Sami
{
    public class Startup
    {
        private const string MyAllowSpecificOrigins = "Access-Control-Allow-Origin";
        private IConfiguration configuration { get; }
        
        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            //establish CORS authorisation for frontend
            services.AddCors(opt => 
            {
                opt.AddPolicy(MyAllowSpecificOrigins,
                    builder =>
                    { 
                        builder.AllowAnyOrigin();
                        builder.AllowAnyHeader();
                        builder.AllowAnyMethod();
                    });
            });

            services.AddControllers();

            // connection string is in appsettings.json
            services.AddDbContext<MyDbContext>(opt =>
                opt.UseSqlServer(configuration.GetConnectionString("myDataBaseConnection"))
            );

            // link interface with DB
            services.AddScoped<IPropertyRepo,SqlPropertyRepo>();
            services.AddScoped<IClientRepo,SqlClientRepo>();
            services.AddScoped<IContractRepo,SqlContractRepo>();

            //Json pour patch route
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
            app.UseCors(MyAllowSpecificOrigins);
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}