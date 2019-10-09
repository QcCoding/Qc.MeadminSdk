using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Cryptography;
using Microsoft.Extensions.Options;
using Qc.MeadminSdk.Models;
using React.AspNet;
using React;

namespace Qc.MeadminSdk
{
    public static class BuilderExtensions
    {
        public static IApplicationBuilder UseMeadminSdk(this IApplicationBuilder app, Action<MeadminOptions> setupAction = null)
        {
            if (setupAction == null)
            {
                app.UseMiddleware<MeadminMiddleware>();
            }
            else
            {
                MeadminOptions meadinOptions = new MeadminOptions();
                setupAction(meadinOptions);
                UseMiddlewareExtensions.UseMiddleware<MeadminMiddleware>(app, new object[1]
                {
                    Options.Create(meadinOptions)
                });

            }
            app.UseReact(config =>
            {
                config
                  .SetLoadBabel(true)
                  .SetBabelVersion(BabelVersions.Babel6);
            });
            return app;
        }
    }
}
