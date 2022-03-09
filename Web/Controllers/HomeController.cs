using IRepository;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Web.Common;
using Web.Common.Filter;

namespace Web.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController()
        {

        }
        [LogActionFilter]
        public ActionResult Index()
        {
            ViewBag.Title = "彭大大平台系统";
            ViewBag.UserName = Param.sessionUserName;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}