using MyCreek.SysAdmin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MyCreek.Web.Controllers
{
    public class MyFeatureController : MyCreekControllerBase
    {

        private readonly IMyFeatureAppService _myFeatureAppService;
        public MyFeatureController(IMyFeatureAppService myFeatureAppService)
        {
            _myFeatureAppService = myFeatureAppService;
        }

        // GET: MyFeature
        public async Task<ActionResult> Index(string menuGuid)
        {
            var info = await _myFeatureAppService.GetMenuInfo(menuGuid);
            //根据ID找到不同的页面
            ViewBag.MenuGuid = menuGuid;
            ViewBag.FeatureTitle = "测试自定义功能";
            ViewBag.FeatureSubTitle = "测试自定义功能子标题";
            ViewBag.ListContent = info.MenuItemDefine.IndexPageTemplate;
            return View();
        }
    }
}