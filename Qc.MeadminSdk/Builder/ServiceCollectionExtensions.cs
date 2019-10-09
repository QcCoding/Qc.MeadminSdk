using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Qc.MeadminSdk
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 添加我的后台框架SDK，注入默认实现的DefaultMeadminSdkHook
        /// </summary>
        /// <param name="services"></param>
        /// <param name="optionsAction"></param>
        /// <returns></returns>
        public static IServiceCollection AddMeadminSdk(this IServiceCollection services, Action<MeadminOptions> optionsAction = null)
        {
            if (optionsAction != null)
            {
                services.Configure(optionsAction);
            }

            return services;
        }

    }
}
