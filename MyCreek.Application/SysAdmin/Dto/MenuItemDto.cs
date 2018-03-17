using Abp.AutoMapper;
using MyCreek.Modules.SysAdmin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCreek.SysAdmin.Dto
{
    [AutoMapFrom(typeof(MenuItemDefine))]
    public class MenuItemDto
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
