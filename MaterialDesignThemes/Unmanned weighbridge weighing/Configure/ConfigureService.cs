using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unmanned_weighbridge_weighing.ViewModels;
using Unmanned_weighbridge_weighing.Views;

namespace Unmanned_weighbridge_weighing.Configure
{
    public class ConfigureService
    {
        //注册
        public static IServiceProvider Load()
        {
            var services = new ServiceCollection();

            //注册UI层
            services.AddSingleton<ShellView>();
            services.AddSingleton<ShellViewModel>();
            services.AddSingleton<LoginView>();
            services.AddSingleton<LoginViewModel>();




            return services.BuildServiceProvider();
        }
    }
}
