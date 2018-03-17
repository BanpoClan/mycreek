using Abp.Domain.Repositories;
using Abp.EntityFramework;
using MyCreek.Modules.Repository;
using MyCreek.Modules.SysAdmin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCreek.EntityFramework.Repositories
{
    public class MenuMgrRepository: MyCreekRepositoryBase<MenuItemDefine>, IMenuMgrRepository
    {
        public MenuMgrRepository(IDbContextProvider<MyCreekDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<MenuItemDefine> GetSingleMenuItemDefine(string menuGuid)
        {
            var data = await SingleAsync(c=>c.MenuGuid== menuGuid);

            return data;
        }
    }
}
