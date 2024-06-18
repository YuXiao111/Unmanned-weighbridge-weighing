using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Company.Sqlite.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Unmanned_weighbridge_weighing.Interfaces;

namespace Unmanned_weighbridge_weighing.ViewModels
{
    internal class LoginViewModel: ObservableObject
    {
        public ICommand LoginCommand { get; }


        public ISession Session { get;  }

        public IUserRepository UserRepository { get; }
        public LoginViewModel(ISession session,IUserRepository userRepository)
        {
            Session = session;
            UserRepository = userRepository;
            LoginCommand = new RelayCommand(Login);

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

            }
            else
            {
                MessageBox.Show("用户名或密码错误");
            }
        }
    }
}
