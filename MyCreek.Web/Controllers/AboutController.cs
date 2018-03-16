using System.Web.Mvc;

namespace MyCreek.Web.Controllers
{
    public class AboutController : MyCreekControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}