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
using AbpPlusPlus.PinYinConverter;
using MyCreek.Modules.Repository;

namespace MyCreek.SysAdmin
{
    public class MenuMgrAppService : MyCreekAppServiceBase, IMenuMgrAppService
    {
        private readonly IMenuMgrRepository _repository;
        private readonly PinYinConverter _converter;
        public MenuMgrAppService(IMenuMgrRepository repository)
        {
            _repository = repository;
            _converter = new PinYinConverter();
        }

        public async Task CreateOrEdit(CreateOrEditInput input)
        {
            int id = 0;
            if (Int32.TryParse(input.Id, out id))
            {
                await CreateAsync(input);
            }
            else
            {
                await UpdateAsync(input);
            }
        }

        protected virtual async Task UpdateAsync(CreateOrEditInput input)
        {
            var menuItemDefine = await _repository.GetSingleMenuItemDefine(input.Id);
            if (menuItemDefine != null)
            {
                menuItemDefine.DisplayName = input.Name;
                menuItemDefine.ParentMenuGuid = input.PId;
                menuItemDefine.Name = _converter.Converter(menuItemDefine.DisplayName);
                await _repository.UpdateAsync(menuItemDefine);
            }
        }

        protected virtual async Task CreateAsync(CreateOrEditInput input)
        {
            var menuItemDefine = new MenuItemDefine();
            menuItemDefine.MenuGuid = Guid.NewGuid().ToString();
            menuItemDefine.ParentMenuGuid = input.PId;
            menuItemDefine.DisplayName = input.Name;
            menuItemDefine.Order = 1;
            menuItemDefine.Name = _converter.Converter(menuItemDefine.DisplayName);
            await _repository.InsertAsync(menuItemDefine);
            await CurrentUnitOfWork.SaveChangesAsync();
        }

        public async Task<PagedResultDto<MenuItemDto>> GetList(GetMenuItemInput input)
        {
            var query = await _repository.GetAllListAsync();

            var count = query.Count();

            var list = query.ToList();

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

        public List<MenuItemDto> GetListDto()
        {
            var query = _repository.GetAll().ToList();
            List<MenuItemDto> list = new List<MenuItemDto>();
            foreach (var item in query)
            {
                MenuItemDto dto = new MenuItemDto();
                dto.id = item.MenuGuid;
                dto.pId = item.ParentMenuGuid;
                dto.name = item.DisplayName;
                if (string.IsNullOrEmpty(item.ParentMenuGuid))
                {
                    dto.open = true;
                }
                list.Add(dto);
            }

            return list;
        }

        public async Task Delete(DeleteMenuInput input)
        {
            var menuItemDefine = await _repository.GetSingleMenuItemDefine(input.MenuGuid);
            if (menuItemDefine != null)
            {
                await _repository.DeleteAsync(menuItemDefine);
            }

        }
    }
}
