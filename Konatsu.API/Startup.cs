using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Konatsu.API.Mapper;
using Konatsu.API.Helpers;
using Konatsu.API.Interfaces;
using Konatsu.API.Services;
using Microsoft.AspNetCore.Server.IISIntegration;

namespace Konatsu.API
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
            services.AddDbContext<DataContext>(options =>
                options
                    .UseNpgsql(Configuration.GetConnectionString("DefaultConnection")
                    )
            );

            services.AddScoped(typeof(IEfRepository<>), typeof(UserRepository<>));

            services.AddAutoMapper(typeof(UserProfile));
            services.AddCors();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Konatsu.API", Version = "v1" });
            });
            services.AddScoped<IUserService, UserService>();

            /*services.AddAuthentication(IISDefaults.AuthenticationScheme);

            services.AddAuthentication()
                .AddCookie(options =>
                {
                    options.LoginPath = "/Account/Unauthorized/";
                    options.AccessDeniedPath = "/Account/Forbidden/";
                })
                .AddJwtBearer(options =>
                {
                    options.Audience = "http://localhost:44240/";
                    options.Authority = "http://localhost:44240/";
                });*/
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Konatsu.API v1"));
            }

            app.UseRouting();

            app.UseMiddleware<JwtMiddleware>();

            // app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
