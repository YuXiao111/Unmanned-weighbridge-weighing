using CommunityToolkit.Mvvm.ComponentModel;
using Company.Sqlite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unmanned_weighbridge_weighing.Interfaces;

namespace Unmanned_weighbridge_weighing.Services
{
    public class Session : ObservableObject, ISession
    {
        private string title;
        public string Title { get => title; set => SetProperty(ref title, value); }

        private User user=new User();
        public User CurrentUser { get => user; set => SetProperty(ref user, value);}
    }
}
