
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
using Qc.MeadminSdk.Models;
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
            services.AddMeadminSdk();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            var authList = new List<SampleauthUserItem>();
            authList.Add(new SampleauthUserItem() { Username = "test", Userpwd = "test", Userkey = "home,user_user_list,user_user_create,user_user_edit" });
            app.UseSampleauthSdk(opt =>
            {
                //Configuration.GetSection("SampleauthSetting").Bind(opt);
                var meadminOpt = Configuration.GetSection("MeadminOptions").Get<MeadminOptions>();
                opt.RoutePrefix = meadminOpt.RoutePrefix;
                //opt.LoginPath = meadminOpt.LoginPath;
                //opt.LogoutPath = meadminOpt.LogoutPath;
                opt.SampleauthList = authList;
                opt.PageSetting = new Dictionary<string, string>();
                opt.PageSetting.Add(SampleauthPageConst.LoginHeadStyle, ".login_input{height:40px;}");
                opt.PageSetting.Add(SampleauthPageConst.LoginTextPageTitle, meadminOpt.SysTitle);
                opt.SignInBeforeHook = (httpContext, username, userpwd) =>
                {
                    var existUser = authList.FirstOrDefault(s => s.Username == username && s.Userpwd == userpwd);
                    if (existUser != null)
                    {
                        httpContext.Response.Cookies.Append("LOGIN_USERNAME", existUser.Username, new CookieOptions()
                        {
                            Expires = DateTime.Now.AddMonths(1)
                        });
                    }
                    return false;
                };
            });
            app.UseMeadminSdk(opt =>
            {
                Configuration.GetSection("MeadminOptions").Bind(opt);
                opt.AuthHandler = httpContext =>
                {
                    var loginUsername = httpContext.Request.Cookies["LOGIN_USERNAME"];

                    return new MeadminSystemInfoModel()
                    {
                        AuthName = loginUsername,
                        Menus = ModulesHelper.GetBackendAllMenus(),
                        Modules = authList.FirstOrDefault(s => s.Username == loginUsername).Userkey
                    };
                };

            });

            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}
