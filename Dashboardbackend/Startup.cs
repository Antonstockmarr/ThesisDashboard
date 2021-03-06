using Dashboardbackend.Data;
using Dashboardbackend.Data.ApproachRepo;
using Dashboardbackend.Data.ApproachToolRepo;
using Dashboardbackend.Data.ConfigurationPackageRepo;
using Dashboardbackend.Data.ConfigurationRepo;
using Dashboardbackend.Data.ToolRepo;
using Dashboardbackend.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace Dashboardbackend
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
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DashBoardConnectionString")));

            //services.AddDbContext<ApplicationContext>(opt => opt.UseSqlServer
            //(Configuration.GetConnectionString("DashBoardConnectionString")));

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                    builder.SetIsOriginAllowed(_ => true)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
            services.AddControllers();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IObjectiveRepository, ObjectiveRepository>();
            services.AddScoped<IConcernRepository, ConcernRepository>();
            services.AddScoped<IApproachRepository, ApproachRepository>();
            services.AddScoped<IToolRepository, ToolRepository>();
            services.AddScoped<IApproachToolRepository, ApproachToolRepository>();
            services.AddScoped<IConfigurationRepository, ConfigurationRepository>();
            services.AddScoped<IConfigurationPackageRepository, ConfigurationPackageRepository>();

            services.AddScoped<ISolutionService, SolutionService>();
            services.AddScoped<IApproachService, ApproachService>();
            services.AddScoped<IConcernService, ConcernService>();
            services.AddScoped<IObjectiveService, ObjectiveService>();
            services.AddScoped<IToolService, ToolService>();
            services.AddScoped<IApproachToolService, ApproachToolService>();
            services.AddScoped<IConfigurationService, ConfigurationService>();
            services.AddScoped<IConfigurationPackageService, ConfigurationPackageService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Dashboardbackend", Version = "v1" });
            });

            services.AddTransient<DataSeeder>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DataSeeder dataSeeder)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Dashboardbackend v1"));
            }

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            dataSeeder.Seed().Wait();
        }
    }
}
