using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;

namespace MyCreek.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : MyCreekControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}