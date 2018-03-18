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
    public class FieldsMgrRepository : MyCreekRepositoryBase<Field>, IFieldsMgrRepository
    {
        public FieldsMgrRepository(IDbContextProvider<MyCreekDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<List<Field>> GetFields(string menuGuid)
        {
            return await GetAllListAsync(c => c.MenuItemDefine_MenuGuid == menuGuid);
        }
    }
}
