using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MyCreek.Modules.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMModule.Dto
{
    /// <summary>
    /// 返回单个对象和列表对象
    /// </summary>
    [AutoMapFrom(typeof(CustomerInfo))]
    public class CustomerInfoDto : EntityDto
    {
        public string CustomerName { get; set; }
        public string CustomerNum { get; set; }
        public string CustomerCategory { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Contacts { get; set; }
        public string Email { get; set; }
    }
}
