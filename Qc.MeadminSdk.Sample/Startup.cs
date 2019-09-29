
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Qc.MeadminSdk;
using Qc.SampleauthSdk;

namespace Qc.MeadminSdk.Sample
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMeadminSdk(Configuration.GetSection("MeadminOptions").Bind);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSampleauthSdk(opt =>
            {
                opt.PageSetting = new Dictionary<string, string>()
                {
                    { SampleauthPageConst.LoginTextPageTitle,Configuration.GetSection("MeadminOptions").GetValue<string>("SysTitle")}
                };
                opt.RoutePrefix = Configuration.GetSection("MeadminOptions").GetValue<string>("RoutePrefix");
                opt.SampleauthList = new List<SampleauthUserItem>();
                opt.SampleauthList.Add(new SampleauthUserItem() { Username = "test", Userpwd = "test" });
            });
            app.UseMeadminSdk(httpContext =>
            {
                return new SystemInfoModel()
                {
                    AuthName = "test",
                    Modules = "*",
                    Menus = ModulesHelper.GetBackendAllMenus()
                };
            });
            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}
