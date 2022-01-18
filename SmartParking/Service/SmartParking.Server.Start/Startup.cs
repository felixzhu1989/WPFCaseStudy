using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartParking.Server.Configuration;
using SmartParking.Server.IConfiguration;
using SmartParking.Server.IService;
using SmartParking.Server.Service;

namespace SmartParking.Server.Start
{
    public class Startup
    {
        public Startup(Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public Microsoft.Extensions.Configuration.IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //注册
            services.AddTransient<IConfiguration.IConfiguration, Configuration.Configuration>();
            services.AddTransient<IEFContext.IEFContext,EFContext.EFContext>();
            services.AddTransient<IUtils, Utils>();
            services.AddTransient<ILoginService, LoginService>();
            services.AddTransient<IMenuService, MenuService>();
            services.AddTransient<IUserService, UserService>();
            //...继续注册新添加的服务





            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
