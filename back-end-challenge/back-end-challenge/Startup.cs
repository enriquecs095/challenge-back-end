using back_end_challenge.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using back_end_challenge.Repositories;
using back_end_challenge.Repositories.UserRepository;

namespace back_end_challenge
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

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder
                           .WithOrigins(Configuration.GetSection("Frontend-Server").Get<String>())
                           .WithHeaders(Configuration.GetSection("Access-Control-Allow-Headers").Get<String[]>())
                           .WithMethods(Configuration.GetSection("Access-Control-Allow-Methods").Get<String[]>());
                });
            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "back_end_challenge", Version = "v1" });
            });
            services.AddDbContext<postgresContext>((s, o) => o.UseNpgsql(Configuration.GetSection("ConnectionDBPostgreServer").Get<string>()));
            services.AddScoped<ILoginRepository,LoginRepository>();
            services.AddScoped<ITimelineRepository, TimelineRepository>();
            services.AddScoped<IFollowingRepository, FollowingRepository>();
            services.AddScoped<IFollowerRepository, FollowerRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "back_end_challenge v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();
    
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
