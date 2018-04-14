using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCreek.Roles.Dto
{
   
    public class GetRolePagedInput : IPagedResultRequest, ISortedResultRequest
    {
        public string MenuGuid { get; set; }
        public string Filter { get; set; }

        [Range(1, 1000)]
        public int MaxResultCount { get; set; }

        [Range(0, int.MaxValue)]
        public int SkipCount { get; set; }
        public string Sorting { get; set; } = "id";

        public GetRolePagedInput()
        {
            MaxResultCount = 10;
        }
    }
}
