using System;
using AutoMapper;
using Backend_RentHouse_Khalifa_Sami.DAL;
using Backend_RentHouse_Khalifa_Sami.DAL.ClientData;
using Backend_RentHouse_Khalifa_Sami.DAL.ContractData;
using Backend_RentHouse_Khalifa_Sami.DAL.PropertyData;
using Backend_RentHouse_Khalifa_Sami.GraphQL;
using GraphQL.Server.Ui.Voyager;
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
        public IConfiguration Configuration { get; }
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // connection string is in appsettings.json
            services.AddDbContext<MyDbContext>(opt =>
                opt.UseSqlServer(Configuration.GetConnectionString("myDataBaseConnection"))
            );
            
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

            // link interface with class for dependency injection
            services.AddScoped<IPropertyRepo,SqlPropertyRepo>();
            services.AddScoped<IClientRepo,SqlClientRepo>();
            services.AddScoped<IContractRepo,SqlContractRepo>();

            services
                .AddGraphQLServer()
                .AddProjections()
                .AddQueryType<Queries>();
                /*.AddMutationType<Mutations>()
                .AddSubscriptionType<Subscriptions>();*/
            
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
            // app.UseAuthorization();
            // app.UseHttpsRedirection();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                // endpoints.MapGraphQL();
            });

            //Schematisation des requetes
            app.UseGraphQLVoyager(new VoyagerOptions
            {
                GraphQLEndPoint = "/graphql"
            });
        }
    }
}