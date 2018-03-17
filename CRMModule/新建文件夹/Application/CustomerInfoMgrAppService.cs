using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using CRMModule.Dto;

namespace CRMModule.Application
{
    public class CustomerInfoMgrAppService : ICustomerInfoMgrAppService
    {
        public Task CreateOrUpdateObj(CreateOrEditCustomerInfoInput input)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUser(EntityDto<long> input)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResultDto<CustomerInfoDto>> GetList(GetCustomerInfoInput input)
        {
            throw new NotImplementedException();
        }

        public Task<CustomerInfoDto> GetObjForEdit(NullableIdDto<long> input)
        {
            throw new NotImplementedException();
        }
    }
}
