using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Sqlite.Models
{
    /// <summary>
    /// 实体类型
    /// </summary>
    public class EntityBase : ObservableObject
    {
        private int id;
        /// <summary>
        /// 自增主键
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//自动递增
        public int Id { get => id; set => SetProperty(ref id, value); }


        private DateTime insertDate = DateTime.Now;
        /// <summary>
        /// 插入时间
        /// </summary>
        public DateTime InsertDate { get => insertDate; set => SetProperty(ref insertDate, value);}

    }
}
