using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Unmanned_weighbridge_weighing.Configure;
using Unmanned_weighbridge_weighing.Views;

namespace Unmanned_weighbridge_weighing
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        public new static App Current=>(App)Application.Current;
        public IServiceProvider Services { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Services.GetService<ShellView>().Show();

        }

        public App()
        {
            Services = ConfigureService.Load();
        }
    }
}
