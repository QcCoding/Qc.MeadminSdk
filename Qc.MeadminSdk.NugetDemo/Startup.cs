using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Qc.MeadminSdk;
using Qc.MeadminSdk.Models;

namespace Qc.MeadminSdk.NugetDemo
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
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMeadminSdk(opt =>
            {
                Configuration.GetSection("MeadminOptions").Bind(opt);
                // 菜单权限
                opt.AuthHandler = httpContext =>
                {
                    var loginUsername = "admin";// httpContext.Request.Cookies["LOGIN_USERNAME"];

                    return new MeadminSystemInfoModel()
                    {
                        AuthName = loginUsername,
                        //根据需要添加菜单
                        Menus = ModulesHelper.GetBackendAllMenus(),//获取根据特性标记生成的菜单
                        Modules = "*" //* 表示所有权限，//authList.FirstOrDefault(s => s.Username == loginUsername).Userkey
                    };
                };
            });
            app.UseRouting();
            app.UseStaticFiles();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}