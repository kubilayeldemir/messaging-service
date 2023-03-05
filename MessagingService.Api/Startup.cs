using System;
using MessagingService.Api.Persistence.Contexts;
using MessagingService.Api.Repositories;
using MessagingService.Api.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace MessagingService.Api
{
    public class Startup
    {
        public static readonly string JwtSecretKey =
            "Z4UVcMcTqDWexjMjSEGywuRtz9WppjGkzNdC5664xzZFp9A5eVg7qrqnwaWQdJX37UDQh9mhb2nSSnRAZH3pH4vn"; //TODO get from env
        private static readonly string DbConnString = "Username=postgres;Password=1997;Server=localhost;Port=5432;Database=message;Trust Server Certificate=true;";
        //TODO use dockerized pg 
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddRouting(opt => opt.LowercaseUrls = true);
            
            services.AddDbContext<DataContext>(options => options.UseNpgsql(DbConnString));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "MessagingService.Api", Version = "v1"});
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MessagingService.Api v1"));
            }
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<DataContext>();
                context.Database.Migrate();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}