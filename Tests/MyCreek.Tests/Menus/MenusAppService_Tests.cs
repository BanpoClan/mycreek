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

        [Fact]
        public async Task GetUsers_Test()
        {
            //Act
            GetFieldInput input = new GetFieldInput();
            input.MenuGuid = "42a0ab72-1ff4-4187-98db-488636841968";
            var output = await menuMgrAppService.GetFields(input);

            //Assert
            output.Count.ShouldBeGreaterThan(3);
        }

       
    }
}
