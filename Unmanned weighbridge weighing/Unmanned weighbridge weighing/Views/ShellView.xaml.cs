using CommunityToolkit.Mvvm.Messaging;
using Company.Core.Config;
using Company.Sqlite.Interfaces;
using Company.Sqlite.Models;
using Company.Sqlite.Repositories;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Unmanned_weighbridge_weighing.Interfaces;
using Unmanned_weighbridge_weighing.Models.Login;
using Unmanned_weighbridge_weighing.Models.Message;
using Unmanned_weighbridge_weighing.ViewModels;

namespace Unmanned_weighbridge_weighing.Views
{
    /// <summary>
    /// ShellView.xaml 的交互逻辑
    /// </summary>
    public partial class ShellView : MetroWindow
    {
        private ISession Session { get; }

        public ShellView(IUserRepository userRepository, ISession session, IConfigManager configManager)
        {
            InitializeComponent();
            Session = session;
            //泛型
            DataContext = App.Current.Services.GetService<ShellViewModel>();

            //创建数据库自动注册管理员账号
            User user = userRepository.Select("admin");
            if (user == null)
            {
                user = new User();
                user.UserName = "admin";
                user.PassWord = "12345678";
                user.Role = 0;//0代表超级管理员
                user.InsertDate = DateTime.Now;
                var count = userRepository.Insert(user);
                if (count > 0)

                {
                    MessageBox.Show($"首次运行系统，注册管理员成功！\r\n用户名：admin\r\n密码：12345678");
                }
            }

            //启动时默认显示登录页面,IOC容器获取LoginView的实例
            container.Content = App.Current.Services.GetService<LoginView>();

            //登录成功后跳转到首页
            WeakReferenceMessenger.Default.Register<LoginSuccessMessage>(this, (sender, args) =>
            {
                //configManager.Write(ConfigKey.LoginUser, new LoginUser { UserName = args.Value.UserName, LoginDate = DateTime.Now });
                Session.CurrentUser = args.Value;
                container.Content = App.Current.Services.GetService<MainView>();
                WindowState = WindowState.Normal;
                Width = 1880;
                Height = 1000;
                SetWindow();
            });
        }

        private void SetWindow()
        {
            Left = (SystemParameters.WorkArea.Width - Width) / 2;
            Top = (SystemParameters.WorkArea.Height - Height) / 2;
        }
    }
}
