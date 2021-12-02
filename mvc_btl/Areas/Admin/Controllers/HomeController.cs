using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace mvc_btl.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult login()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult tacgia()
        {
            return View();
        }
        

    }
}
