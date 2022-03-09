using Common.Helpers;

using Service.System.Auth;
using Service.System.Auth.Input;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Web.Common;
using Web.Common.Filter;

namespace Web.Controllers
{
    [IgnoreAllowAnonymous]
    public class LoginController : BaseController
    {
        IAuthService _authService;

        public LoginController(IAuthService authService)
        {
            _authService = authService;
        }
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Login(AuthLoginInput input)
        {
            return Json(_authService.Login(input));
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