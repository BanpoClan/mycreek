using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using MyCreek.SysAdmin.Dto;
using Abp.Domain.Repositories;
using MyCreek.Modules.SysAdmin;
using Abp.Collections.Extensions;
using Abp.AutoMapper;

namespace MyCreek.SysAdmin
{
    public class MenuMgrAppService : MyCreekAppServiceBase, IMenuMgrAppService
    {
        private readonly IRepository<MenuItemDefine> _repository;
        public MenuMgrAppService(IRepository<MenuItemDefine> repository)
        {
            _repository = repository;
        }
        public async Task<PagedResultDto<MenuItemDto>> GetList(GetMenuItemInput input)
        {
            var query = await _repository.GetAllListAsync();
            
            var count =  query.Count();
            
            var list =  query.ToList();

            var result = list.MapTo<List<MenuItemDto>>();

            return new PagedResultDto<MenuItemDto>(
                count,
                result
                );
        }

        public List<MenuItemDefine> GetList()
        {
            var query = _repository.GetAll();
            var list = query.ToList();
            return list;
        }
    }
}
