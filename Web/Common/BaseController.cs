using System.Web.Mvc;

using Web.Filter;

namespace Web.Common
{
    //[LogActionFilter]
    public class BaseController : Controller
    {
        /// <summary>
        /// 自定义JSON返回
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        protected JsonResult ResultJson(object data, JsonRequestBehavior behavior)
        {
            return new NewJsonResult
            {
                Data = data,
                JsonRequestBehavior= behavior
            };
        }

        protected JsonResult ResultJson(object data)
        {
            return new NewJsonResult
            {
                Data = data
            };
        }
    }
}