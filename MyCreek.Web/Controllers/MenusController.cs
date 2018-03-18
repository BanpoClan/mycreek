using MyCreek.SysAdmin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MyCreek.Web.Controllers
{
    public class MenusController : MyCreekControllerBase
    {

        private readonly IMenuMgrAppService _menuMgrAppService;
        public MenusController(IMenuMgrAppService menuMgrAppService)
        {
            _menuMgrAppService = menuMgrAppService;
        }

        // GET: Menus
        public ActionResult Index()
        {
            return View();
        }


        public async Task<PartialViewResult> PartialFieldModal(string menuGuid, int id)
        {

            ViewBag.ColName = "";
            ViewBag.ColType = "";
            ViewBag.IsNull = false;
            ViewBag.MenuItemDefine_MenuGuid = menuGuid;
            ViewBag.id = id;

            if (id > 0)
            {
                var data = await _menuMgrAppService.GetField(new SysAdmin.Dto.FieldDto() { Id = id });

                ViewBag.ColName = data.ColName;
                ViewBag.ColType = data.ColType;
                ViewBag.IsNull = data.IsNull;
                ViewBag.MenuItemDefine_MenuGuid = data.MenuItemDefine_MenuGuid;
            }
            return PartialView("_PartialFieldModal");
        }
    }
}