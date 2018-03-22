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
    public interface IMenuMgrAppService : IApplicationService
    {
        /// <summary>
        /// 构造动态菜单
        /// </summary>
        /// <returns></returns>
        List<MenuItemDefine> GetList();
        /// <summary>
        /// 构造菜单树
        /// </summary>
        /// <returns></returns>
        List<MenuItemDto> GetListDto();
        /// <summary>
        /// 创建或编辑菜单
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrEdit(CreateOrEditInput input);
        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task Delete(DeleteMenuInput input);
        /// <summary>
        /// 菜单附加信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task AddAdditional(AdditionalInput input);
        /// <summary>
        /// 获取字段
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        PagedResultDto<FieldDto> GetFields(GetFieldPagedInput input);
        Task CreateOrEditField(FieldInput input);

        Task<FieldDto> GetField(FieldDto input);

        Task DeleField(int id);

        /// <summary>
        /// 获取菜单的所有信息
        /// </summary>
        /// <param name="menuGuid"></param>
        /// <returns></returns>
        Task<CustomFeatureCoreStruct> GetMenuInfo(string menuGuid);

        /// <summary>
        /// 创建数据库表
        /// </summary>
        /// <param name="menuGuid"></param>
        /// <returns></returns>
        Task CreateCustomFeatureStruct(string menuGuid);

        /// <summary>
        /// 修改模板
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task UpdateMenuTemplate(TemplateInput input);

        /// <summary>
        /// 点击菜单，插入一条数据
        /// </summary>
        /// <param name="menuGuid"></param>
        /// <returns></returns>
        Task SetMenuStatus(string menuGuid);
        /// <summary>
        /// 获取该条数据，用以展开菜单
        /// </summary>
        /// <returns></returns>
        Task<string> GetMenuStatus();
    }
}
