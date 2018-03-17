using Abp.Application.Services;
using Abp.Application.Services.Dto;
using CRMModule.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMModule.Application
{
    public interface ICustomerInfoMgrAppService : IApplicationService
    {
        Task<PagedResultDto<CustomerInfoDto>> GetList(GetCustomerInfoInput input);

        Task<CustomerInfoDto> GetObjForEdit(NullableIdDto<long> input);
        Task CreateOrUpdateObj(CreateOrEditCustomerInfoInput input);

        Task DeleteUser(EntityDto<long> input);


    }
}
