using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCreek.Modules.SysAdmin
{
    /// <summary>
    /// 自定义菜单
    /// </summary>
    public class MenuItemDefine : FullAuditedEntity
    {
        public string MenuGuid { get; set; }
        public string ParentMenuGuid { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
        public int Order { get; set; }

    }
}
