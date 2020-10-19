using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BSWTranslationTools.API.Data;
using BSWTranslationTools.API.Repository;
using BSWTranslationTools.API.Repository.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using UserManagementAPI.Mappings;
using UserManagementAPI.Repository;
using UserManagementAPI.Repository.Contracts;

namespace BSWTranslationTools.API
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
            services.AddDbContext<JsonDbContext>(options =>
               options.UseSqlServer(
                   Configuration.GetConnectionString("DefaultConnection")));
            services.AddCors(o =>
            {
                o.AddPolicy("CrosPolicy",
                    builder => builder.AllowAnyOrigin().
                    AllowAnyMethod().
                    AllowAnyHeader());
            });
            services.AddAutoMapper(typeof(Maps));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "BSW Translation Tools API",
                    Version = "v1",
                    Description = "BSW Translation Tools API"
                });
            });
            services.AddSingleton<ILoggerService, LoggerService>();
            services.AddScoped<IJsonDetailsRepository, JsonDetailsRepository>();
            //services.AddScoped<IAudit_logs, AuditService>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "BSW Translation Tools API");
                //c.RoutePrefix = "";
            });

            app.UseHttpsRedirection();

            app.UseCors("CrosPolicy");

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
