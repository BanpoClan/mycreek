using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using MyCreek.Configuration.Dto;

namespace MyCreek.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : MyCreekAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
