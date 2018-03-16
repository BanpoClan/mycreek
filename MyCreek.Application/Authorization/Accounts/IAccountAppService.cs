using System.Threading.Tasks;
using Abp.Application.Services;
using MyCreek.Authorization.Accounts.Dto;

namespace MyCreek.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
