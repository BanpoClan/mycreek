using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MyCreek.MultiTenancy.Dto;

namespace MyCreek.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
