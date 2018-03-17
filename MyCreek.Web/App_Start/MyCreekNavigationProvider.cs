using Abp.Application.Navigation;
using Abp.Localization;
using MyCreek.Authorization;
using MyCreek.Localization;
using MyCreek.Modules.SysAdmin;
using MyCreek.SysAdmin;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
namespace MyCreek.Web
{
    /// <summary>
    /// This class defines menus for the application.
    /// It uses ABP's menu system.
    /// When you add menu items here, they are automatically appear in angular application.
    /// See Views/Layout/_TopMenu.cshtml file to know how to render menu.
    /// </summary>
    public class MyCreekNavigationProvider : NavigationProvider
    {
        private readonly IMenuMgrAppService _menuMgrAppService;
        public MyCreekNavigationProvider(IMenuMgrAppService menuMgrAppService)
        {
            _menuMgrAppService = menuMgrAppService;
        }

        public override void SetNavigation(INavigationProviderContext context)
        {
            CreateMenuTree(context);
        }

        private static ILocalizableString L(string name)
        {
            return new DBLocalizableString(name);
        }

        private void CreateMenuTree(INavigationProviderContext context)
        {
            //获取菜单表数据
            var data = _menuMgrAppService.GetList();
            //通过递归构造数据
            if (data != null)
            {

                var roots = data.Where(c => string.IsNullOrEmpty(c.ParentMenuGuid)).OrderBy(c => c.Order);
                foreach (var item in roots)
                {
                    var menuItem = new MenuItemDefinition(
                           item.Name,
                           L(item.DisplayName),
                           url: item.Url,
                           icon: item.Icon
                       );
                    context.Manager.MainMenu.AddItem(menuItem);
                    BuildTree(menuItem, item,  data);

                }
            }
        }

        private void BuildTree(MenuItemDefinition menuItem, MenuItemDefine item,  List<MenuItemDefine> data)
        {

            //找当前项的子项
            var subMenuList = data.FindAll(c => c.ParentMenuGuid == item.MenuGuid).OrderBy(c => c.Order).ToList();
            foreach (var subItem in subMenuList)
            {
                var subMenuItem = new MenuItemDefinition(
                           subItem.Name,
                           L(subItem.DisplayName),
                           url: subItem.Url,
                           icon: subItem.Icon
                       );
                menuItem.AddItem(subMenuItem);
                BuildTree(subMenuItem, subItem, subMenuList);
            }

        }



    }
}
