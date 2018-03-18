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
using Abp.Application.Services;
using Abp.Authorization;
using Abp.Extensions;
using Abp.Linq.Extensions;
using System.Linq.Dynamic.Core;



namespace MyCreek.SysAdmin
{
    public class MenuMgrAppService : MyCreekAppServiceBase, IMenuMgrAppService
    {
        private readonly IMenuMgrRepository _menuRepository;
        private readonly IFieldsMgrRepository _fieldRepository;
        private readonly PinYinConverter _converter;
        public MenuMgrAppService(IMenuMgrRepository menuRepository, IFieldsMgrRepository fieldRepository)
        {
            _menuRepository = menuRepository;
            _converter = new PinYinConverter();
            _fieldRepository = fieldRepository;
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
            var menuItemDefine = await _menuRepository.GetSingleMenuItemDefine(input.Id);
            if (menuItemDefine != null)
            {
                menuItemDefine.DisplayName = input.Name;
                menuItemDefine.ParentMenuGuid = input.PId;
                menuItemDefine.Name = _converter.Converter(menuItemDefine.DisplayName);
                await _menuRepository.UpdateAsync(menuItemDefine);
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
            await _menuRepository.InsertAsync(menuItemDefine);
            await CurrentUnitOfWork.SaveChangesAsync();
        }

        public async Task<PagedResultDto<MenuItemDto>> GetList(GetMenuItemInput input)
        {
            var query = await _menuRepository.GetAllListAsync();

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
            var query = _menuRepository.GetAll();
            var list = query.ToList();
            return list;
        }

        public List<MenuItemDto> GetListDto()
        {
            var query = _menuRepository.GetAll().ToList();
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
            var menuItemDefine = await _menuRepository.GetSingleMenuItemDefine(input.MenuGuid);
            if (menuItemDefine != null)
            {
                await _menuRepository.DeleteAsync(menuItemDefine);
            }

        }

        public async Task AddAdditional(AdditionalInput input)
        {
            try
            {
                var menuItemDefine = await _menuRepository.GetSingleMenuItemDefine(input.MenuGuid);
                if (menuItemDefine != null)
                {
                    menuItemDefine.Url = input.Url;
                    menuItemDefine.Icon = input.Icon;
                    menuItemDefine.Order = input.Order;
                    menuItemDefine.Description = input.Description;
                    menuItemDefine.DBTable = input.DBTable;
                    menuItemDefine.ExecSQL = input.ExecSQL;
                    menuItemDefine.DBView = input.DBView;
                    menuItemDefine.Procedure = input.Procedure;
                    await _menuRepository.UpdateAsync(menuItemDefine);
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public PagedResultDto<FieldDto> GetFields(GetFieldPagedInput input)
        {
            var query = _fieldRepository.GetAll()
                  .WhereIf(!string.IsNullOrEmpty(input.Filter), t => t.ColName.Contains(input.Filter)).OrderBy(c=>c.Id);

            var count = query.Count();
            var list = query.PageBy(input).ToList();
            var data = new PagedResultDto<FieldDto>(count, list.MapTo<List<FieldDto>>());
            return data;
        }
    }
}
