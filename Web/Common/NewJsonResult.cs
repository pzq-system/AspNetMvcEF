using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Common
{
    public class NewJsonResult : JsonResult
    {
        /// <summary>
        /// 日期格式
        /// </summary>
        public string DateFormatStr { get; set; } = "yyyy-MM-dd HH:mm:ss";

		public override void ExecuteResult(ControllerContext context)
		{
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if (JsonRequestBehavior == JsonRequestBehavior.DenyGet && string.Equals(context.HttpContext.Request.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException("此请求已被阻止，因为当用在 GET 请求中时，会将敏感信息透漏给第三方网站。若要允许 GET 请求，请将 JsonRequestBehavior 设置为 AllowGet。");
            }
            HttpResponseBase response = context.HttpContext.Response;
			if (!string.IsNullOrEmpty(ContentType))
			{
				response.ContentType = ContentType;
			}
			else
			{
				response.ContentType = "application/json";
			}
			if (ContentEncoding != null)
			{
				response.ContentEncoding = ContentEncoding;
			}
			if (Data != null)
			{
                JsonTextWriter writer = new JsonTextWriter(response.Output) { Formatting = Formatting.Indented, DateFormatString = DateFormatStr };
                JsonSerializer serializer = JsonSerializer.Create(new JsonSerializerSettings());
                serializer.Serialize(writer, Data);
                writer.Flush();
            }
		}
	}
}