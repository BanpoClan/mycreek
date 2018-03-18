using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCreek.Modules.SysAdmin
{
    /// <summary>
    /// 数据库列对象 
    /// </summary>
    public class Field : Entity
    {
        public string ColName { get; set; }
        public string ColType { get; set; }
        public bool IsNull { get; set; }

        public string MenuItemDefine_MenuGuid { get; set; }
        
    }
}
