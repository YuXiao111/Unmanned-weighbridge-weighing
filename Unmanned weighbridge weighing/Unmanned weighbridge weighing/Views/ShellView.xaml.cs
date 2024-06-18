using Company.Sqlite.Interfaces;
using Company.Sqlite.Models;
using Company.Sqlite.Repositories;
using MahApps.Metro.Controls;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
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
using Unmanned_weighbridge_weighing.ViewModels;

namespace Unmanned_weighbridge_weighing.Views
{
    /// <summary>
    /// ShellView.xaml 的交互逻辑
    /// </summary>
    public partial class ShellView : MetroWindow
    {
        public ShellView(IUserRepository userRepository)
        {
            InitializeComponent();
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

            //启动时默认显示登录页面
            container.Content = App.Current.Services.GetService<LoginView>();

        }
    }
}
