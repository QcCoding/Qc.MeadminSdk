using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Cryptography;
using Microsoft.Extensions.Options;

namespace Qc.MeadminSdk
{
    public static class BuilderExtensions
    {
        internal static Func<HttpContext, SystemInfoModel> AuthHandler = s => null;
        public static IApplicationBuilder UseMeadminSdk(this IApplicationBuilder app, Func<HttpContext, SystemInfoModel> authHandler = null, Action<MeadminOptions> setupAction = null)
        {
            AuthHandler = authHandler;
            if (setupAction == null)
            {
                app.UseMiddleware<MeadminMiddleware>();
            }
            else
            {
                MeadminOptions authOptions = new MeadminOptions();
                setupAction(authOptions);
                UseMiddlewareExtensions.UseMiddleware<MeadminMiddleware>(app, new object[1]
                {
                    Options.Create(authOptions)
                });
            }
            return app;
        }
    }
}
