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
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WS_RadarFamily.Repository;
using WS_RadarFamily.Repository.Interface;
using WS_RadarFamily.Service;
using WS_RadarFamily.Service.Interface;

namespace WS_RadarFamily
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static string ConnectionString
        {
            get;
            private set;
        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IConfiguration>(Configuration);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddTransient<ILoginService, LoginService>();
            services.AddTransient<IPositionService, PositionService>();
            services.AddTransient<IUnitTrackerService, UnitTrackerService>();
            services.AddTransient<ILoginRepository, LoginRepository>();
            services.AddTransient<IPositionRepository, PositionRepository>();
            services.AddTransient<IUnitTrackerRepository, UnitTrackerRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            ConnectionString = Configuration["ConnectionStrings:RadarFamily"];

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Login}/{action=Index}");
            });
        }
    }
}
