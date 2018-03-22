using System.Data.Entity;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using MyCreek.Users;
using MyCreek.Users.Dto;
using Shouldly;
using Xunit;
using MyCreek.SysAdmin;
using MyCreek.SysAdmin.Dto;

namespace MyCreek.Tests.Users
{
    public class MenusAppService_Tests : MyCreekTestBase
    {
        private readonly IMenuMgrAppService menuMgrAppService;

        public MenusAppService_Tests()
        {
            menuMgrAppService = Resolve<IMenuMgrAppService>();
        }

        
       
    }
}
