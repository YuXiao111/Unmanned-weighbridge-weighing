using Company.Core.Config;
using Company.Sqlite.Interfaces;
using Company.Sqlite.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unmanned_weighbridge_weighing.Interfaces;
using Unmanned_weighbridge_weighing.Services;
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

            //注册数据层
            services.AddSingleton<IUserRepository,UserRepository>();


            //注册业务层
            services.AddSingleton<ISession,Session>();
            services.AddSingleton<IConfigManager,ConfigManager>();


            //注册UI层
            services.AddSingleton<ShellView>();
            services.AddSingleton<ShellViewModel>();

            services.AddSingleton<LoginView>();
            services.AddSingleton<LoginViewModel>();

            services.AddSingleton<MainView>();
            services.AddSingleton<MainViewModel>();



            return services.BuildServiceProvider();
        }
    }
}
