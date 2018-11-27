using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using VLine.API.DB;
using VLine.API.Repositories;
using VLine.API.Services;

namespace VLine.API
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
            services.AddMvc(options =>
            {
                options.Filters.Add(new CorsAuthorizationFilterFactory("allow-local"));
            });

            services.AddCors(options =>
            {
                options.AddPolicy("allow-local", builder =>
                {
                    builder
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "V/Line Demo API", Version = "v1" });
            });

            // For the purpose of the demo, in-memory db will be used
            services.AddDbContext<DatabaseContext>(opt => opt.UseInMemoryDatabase());

            services.AddScoped<ITimetablesService, TimetablesService>();
            services.AddScoped<ITimetablesRepository, TimetablesRepository>();

            services.AddAutoMapper();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<DatabaseContext>();
            FakeDataProvider.AddTimetables(context);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "V/Line Demo API V1");
                });
            }

            app.UseMvc();
        }
    }
}
