using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using GreatPizzaAPI.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using GreatPizzaAPI.Settings;
using Microsoft.OpenApi.Models;

namespace GreatPizzaAPI
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
            services.AddDbContext<Data.DataContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<Data.DataContext>();
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddSwaggerGen(swaggergen =>
            {
                swaggergen.SwaggerDoc("v1", new OpenApiInfo { Title = "Great Pizza API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
                        app.UseHttpsRedirection();
            app.UseStaticFiles();

            var swaggerSettings = new SwaggerSettings();
            Configuration.GetSection("Swagger").Bind(swaggerSettings);

            app.UseSwagger(option => { option.RouteTemplate = swaggerSettings.JsonRoute; });

            app.UseSwaggerUI(option =>
            {
                option.SwaggerEndpoint(swaggerSettings.UiEndpoint, swaggerSettings.Description);
            });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
