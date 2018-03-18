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
        // GET: Menus
        public ActionResult Index()
        {
            return View();
        }

     
        public PartialViewResult PartialFieldModal()
        {
            return PartialView("_PartialFieldModal");
        }
    }
}