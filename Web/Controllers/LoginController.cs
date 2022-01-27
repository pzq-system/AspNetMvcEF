using Common.Helpers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Web.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Login()
        {

            return Json(new { });
        }

        /// <summary>
        /// 创建验证码返回前段
        /// </summary>
        /// <returns></returns>
        public ActionResult VerificationCode()
        {
            string code = ValidateCodeHelper.CreateCode(4);
            Session["LoginCode"] = code.ToUpper();
            byte[] buffer = ValidateCodeHelper.CreateValidateGraphic(code);
            return File(buffer, "image/Jpeg");
        }
    }
}