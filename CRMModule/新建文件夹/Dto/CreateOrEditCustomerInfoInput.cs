using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMModule.Dto
{
    /// <summary>
    /// 创建和编辑的输入参数
    /// </summary>
    public class CreateOrEditCustomerInfoInput
    {
        public CustomerInfoDto CustomerInfoDto { get; set; }
    }
}
