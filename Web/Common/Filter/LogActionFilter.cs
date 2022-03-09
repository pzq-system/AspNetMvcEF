using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Common.Filter
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class LogActionFilter : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {

            if (filterContext.ActionDescriptor.IsDefined(typeof(IgnoreAllowAnonymous), true))
            {
                return;
            }
            if (filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(IgnoreAllowAnonymous), true))
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(Param.sessionUseraccount))
            {
                //new { code:"0020", msg:"登录过期" }
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    filterContext.Result = new JsonResult
                    {
                        Data = new { code = "0060", Redirect = "~/Error/Index" },
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
                }
                else
                {
                    filterContext.Result = new RedirectResult("~/Error/Index");
                }

            }
            return;
        }
    }
}