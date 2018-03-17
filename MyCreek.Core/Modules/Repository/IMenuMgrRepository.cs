using Abp.Domain.Repositories;
using MyCreek.Modules.SysAdmin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCreek.Modules.Repository
{
    public interface IMenuMgrRepository : IRepository<MenuItemDefine>
    {
        Task<MenuItemDefine> GetSingleMenuItemDefine(string menuGuid);
    }
}
