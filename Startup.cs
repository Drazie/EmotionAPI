using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NotiAPI.Models;
using Microsoft.EntityFrameworkCore;
using NotiAPI.Repositories;
using Microsoft.OpenApi.Models;

namespace NotiAPI
{
    public class Startup
    {
        public static string Conn(string dbName)
        {
            return $"Server=localhost,1433; Database={dbName}; User=sa; Password=Kosha_yoyo1029";
        }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
             
            services.AddScoped<INotificationRepository, NotificationRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            
            

            services.AddDbContext<NotificationContext>
                (opt => opt.UseSqlServer(connectionString:"Server = localhost, 1433; Database = NotiListdb; User = sa; Password = Kosha_yoyo1029"));

            services.AddDbContext<UserContext>
                (opt => opt.UseSqlServer(connectionString:"Server = localhost, 1433; Database = UserListdb; User = sa; Password = Kosha_yoyo1029"));

            

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EmotionAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EmotionAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
