using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Web.Common.Filter;

namespace Web.Controllers
{
    [IgnoreAllowAnonymous]
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index()
        {
            return View();
        }
    }
}