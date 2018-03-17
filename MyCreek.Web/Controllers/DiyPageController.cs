using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyCreek.Web.Controllers
{
    public class DiyPageController : MyCreekControllerBase
    {
        // GET: DiyPage
        public ActionResult Index()
        {
            return View();
        }
    }
}