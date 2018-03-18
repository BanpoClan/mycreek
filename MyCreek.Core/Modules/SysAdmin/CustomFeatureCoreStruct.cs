using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCreek.Modules.SysAdmin
{
    /// <summary>
    /// 自定义功能核心对象
    /// 
    /// 1个menu对应多个字段
    /// </summary>
    public class CustomFeatureCoreStruct:Entity
    {
        public MenuItemDefine MenuItemDefine { get; set; }
        public List<Field> Fields { get; set; }
    }
}
