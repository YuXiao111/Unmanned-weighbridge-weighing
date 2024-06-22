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
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get => userName; set => SetProperty(ref userName, value); }

        private string passWord;
        /// <summary>
        /// 密码
        /// </summary>
        public string PassWord { get => passWord; set => SetProperty(ref passWord, value); }

        private int role;
        /// <summary>
        /// 权限
        /// </summary>
        public int Role { get => role; set => SetProperty(ref role, value);}
    }
}
