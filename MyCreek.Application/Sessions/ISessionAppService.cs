using System.Threading.Tasks;
using Abp.Application.Services;
using MyCreek.Sessions.Dto;

namespace MyCreek.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
