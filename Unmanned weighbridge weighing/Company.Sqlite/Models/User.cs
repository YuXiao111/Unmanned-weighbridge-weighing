using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Sqlite.Models
{
    [Table(nameof(User))]
    public class User : EntityBase
    {
        private string userName;
        public string UserName { get => userName; set => SetProperty(ref userName, value); }

        private string passWord;
        public string PassWord { get => passWord; set => SetProperty(ref passWord, value); }

        private int role;
        public int Role { get => role; set => SetProperty(ref role, value);}
    }
}
