using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LegoPartTracker.API.Entities;
using LegoPartTracker.API.Models;
using LegoPartTracker.API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace LegoPartFinder.API
{
    public class Startup
    {
        public static IConfiguration Configuration { get; private set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddMvc();

            var connectionString = Startup.Configuration["connectionStrings:legoPartFinderConnectionString"];
            services.AddDbContext<SetInfoContext>(o => o.UseSqlServer(connectionString));

            services.AddSingleton<IConfiguration>(Configuration);

            services.AddScoped<ISetInfoRepository, SetInfoRepository>();
            services.AddScoped<IRebrickableInfoRepository, RebrickableInfoRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler();
            }

            app.UseStatusCodePages();

            AutoMapper.Mapper.Initialize(config =>
            {
                config.CreateMap<Set, SetDto>();
                config.CreateMap<Set, SetWithSetPartDto>();
                config.CreateMap<SetPart, SetPartDto>();
                config.CreateMap<SetPart, SetPartForUpdateDto>();
                config.CreateMap<SetPartForUpdateDto, SetPart>();
            });

            app.UseCors(options => options.WithOrigins("http://localhost:4200", "http://192.168.99.100:3000").AllowAnyMethod());

            app.UseMvc();
        }
    }
}
