using System.Threading.Tasks;
using Abp.Application.Services;
using MyCreek.Configuration.Dto;

namespace MyCreek.Configuration
{
    public interface IConfigurationAppService: IApplicationService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}