using Directory.API.Filter;
using Directory.API.Middlewares;
using Directory.Business.Abstract;
using Directory.Business.Concrete;
using Directory.Core.Dto.Mapping;
using Directory.DataAccess.Abstract;
using Directory.DataAccess.Concrete;
using FluentValidation.AspNetCore;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Linq;

namespace Directory.API
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
            services.AddMassTransit(x =>
            {
                //default port :5672

                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(Configuration["RabbitMQ"], "/", host =>
                    {
                        host.Username("guest");
                        host.Password("guest");
                    });
                });
            });
            
            services.AddControllers();
            services.AddMvc(x =>
            {
                x.Filters.Add(typeof(ValidationActionsFilter));
            }).AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<Startup>())
            .AddSessionStateTempDataProvider();
            services.AddSession();
           
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });


            services.AddAutoMapper(typeof(MapProfile));
           
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            services.AddScoped<IContactInformationDal, ContactInformationDal>();
            services.AddScoped<IContactInformationService, ContactInformationManager>();

            services.AddScoped<IInfoTypeDal, InfoTypeDal>();
            services.AddScoped<IInfoTypeService, InfoTypeManager>();

            services.AddScoped<IPersonsDal, PersonsDal>();
            services.AddScoped<IPersonService, PersonsManager>();


            services.AddScoped<ILocationDal, LocationDal>();
            services.AddScoped<ILocationService, LocationManager>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Directory.API", Version = "v1" });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });

        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Directory.API v1"));
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseAuthorization();
            app.UseCustomException();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
