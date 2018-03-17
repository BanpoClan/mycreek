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
    /// <summary>
    /// 附加信息
    /// </summary>
    [AutoMapFrom(typeof(MenuItemDefine))]
    public class AdditionalInput: FullAuditedEntityDto
    {
        public string MenuGuid { get; set; }
        public string ParentMenuGuid { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
        public int Order { get; set; }
        public string Description { get; set; }
        

        /// <summary>
        /// 关联数据库表
        /// </summary>
        public string DBTable { get; set; }

        /// <summary>
        /// 关联SQL
        /// </summary>
        public string ExecSQL { get; set; }

        /// <summary>
        /// 关联视图
        /// </summary>
        public string DBView { get; set; }

        /// <summary>
        /// 关联存储过程
        /// </summary>
        public string Procedure { get; set; }


    }
}
