using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MyCreek.Modules.SysAdmin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCreek.SysAdmin.Dto
{
    [AutoMapTo(typeof(Field))]
    public class FieldDto : EntityDto
    {
        public string ColName { get; set; }
        public string ColType { get; set; }
        public bool IsNull { get; set; }

        public string MenuItemDefine_MenuGuid { get; set; }
    }
}
