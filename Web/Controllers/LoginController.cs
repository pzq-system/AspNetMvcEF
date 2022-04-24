using Common.Helpers;

using Service.System.Auth;
using Service.System.Auth.Dto;

using System;
using System.Web.Mvc;

using Web.Common;

namespace Web.Controllers
{
    public class LoginController : BaseController
    {
        Lazy<IAuthService> _authService;

        public LoginController(Lazy<IAuthService> authService)
        {
            _authService = authService;
        }
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Login(AuthLoginPDto input)
        {
            return Json(_authService.Value.Login(input));
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