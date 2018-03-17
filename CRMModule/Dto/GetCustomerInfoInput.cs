using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMModule.Dto
{
    public class GetCustomerInfoInput : EntityDto
    {
        public string Filter { get; set; }
    }
}
