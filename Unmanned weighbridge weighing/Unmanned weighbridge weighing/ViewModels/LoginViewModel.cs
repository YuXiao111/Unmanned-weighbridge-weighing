using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Company.Core.Config;
using Company.Sqlite.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Unmanned_weighbridge_weighing.Interfaces;
using Unmanned_weighbridge_weighing.Models.Login;
using Unmanned_weighbridge_weighing.Models.Message;

namespace Unmanned_weighbridge_weighing.ViewModels
{
    internal class LoginViewModel: ObservableObject
    {
        public ICommand LoginCommand { get; }

        public ICommand LoadCommand { get; }

        public ISession Session { get;  }

        public IUserRepository UserRepository { get; }

        public IConfigManager ConfigManager { get; }
        public LoginViewModel(ISession session,IUserRepository userRepository,IConfigManager configManager)
        {
            Session = session;
            UserRepository = userRepository;
            ConfigManager = configManager;
            LoginCommand = new RelayCommand(Login);
            LoadCommand = new RelayCommand(Load);

        }

        private void Load()
        {
            var user = ConfigManager.Read<LoginUser>(ConfigKey.LoginUser) ?? new LoginUser();
            Session.CurrentUser.UserName= user.UserName;
        }

        private void Login()
        {
            Session.CurrentUser.PassWord = "12345678";
            if (string.IsNullOrEmpty(Session.CurrentUser.UserName) || string.IsNullOrEmpty(Session.CurrentUser.PassWord))
            {
                MessageBox.Show("用户名或密码为空");
                return;
            }

            var list = UserRepository.GetAll();
            var user=list.Find(t=>t.UserName == Session.CurrentUser.UserName && t.PassWord==Session.CurrentUser.PassWord);

            if (user != null)
            {
                //todo 进入首页
                WeakReferenceMessenger.Default.Send(new LoginSuccessMessage(user));
            }
            else
            {
                MessageBox.Show("用户名或密码错误");
            }
        }
    }
}
