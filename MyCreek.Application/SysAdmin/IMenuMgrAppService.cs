using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MyCreek.Modules.SysAdmin;
using MyCreek.SysAdmin.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCreek.SysAdmin
{
    public interface IMenuMgrAppService: IApplicationService
    {
        List<MenuItemDefine> GetList();
        List<MenuItemDto> GetListDto();
        Task CreateOrEdit(CreateOrEditInput input);
    }
}
