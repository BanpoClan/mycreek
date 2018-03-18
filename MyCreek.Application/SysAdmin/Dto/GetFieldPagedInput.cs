using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCreek.SysAdmin.Dto
{
    /// <summary>
    /// 获取菜单的
    /// </summary>
    public  class GetMenuItemInput 
    {
        public string Filter { get; set; }
    }

    public class GetFieldPagedInput : IPagedResultRequest, ISortedResultRequest
    {
        public string MenuGuid { get; set; }
        public string Filter { get; set; }

        [Range(1, 1000)]
        public int MaxResultCount { get; set; }

        [Range(0, int.MaxValue)]
        public int SkipCount { get; set; }
        public string Sorting { get; set; } = "id";

        public GetFieldPagedInput()
        {
            MaxResultCount = 10;
        }
    }
}
