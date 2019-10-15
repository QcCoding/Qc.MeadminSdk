using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Qc.MeadminSdk.NugetDemo
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            services.AddMeadminSdk(Configuration.GetSection("MeadminOptions").Bind);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMeadminSdk();
            //app.UseMeadminSdk(opt =>
            //{
            //    Configuration.GetSection("MeadminOptions").Bind(opt);
            //    // 菜单权限
            //    opt.AuthHandler = httpContext =>
            //    {
            //        var loginUsername = "admin";// httpContext.Request.Cookies["LOGIN_USERNAME"];
            //        return new MeadminSystemInfoModel()
            //        {
            //            AuthName = loginUsername,
            //            //根据需要添加菜单
            //            Menus = ModulesHelper.GetBackendAllMenus(),//获取根据特性标记生成的菜单
            //            Modules = "*" //* 表示所有权限，//authList.FirstOrDefault(s => s.Username == loginUsername).Userkey
            //        };
            //    };
            //});
            app.UseMvc();
        }
    }
}
