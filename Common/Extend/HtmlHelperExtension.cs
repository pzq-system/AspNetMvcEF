using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Common.Extend
{
    //原文链接：https://blog.csdn.net/a736755244/article/details/103350392
    public static class HtmlHelperExtension
    {
        /// <summary>
        /// 自动为 Js 文件添加版本号
        /// </summary>
        /// <param name="html"></param>
        /// <param name="contentPath"></param>
        /// <returns></returns>
        public static MvcHtmlString Script(this HtmlHelper html, string contentPath)
        {
            return VersionContent(html, "<script src=\"{0}\" type=\"text/javascript\"></script>", contentPath);
        }
        /// <summary>
        /// 自动为 css 文件添加版本号
        /// </summary>
        /// <param name="html"></param>
        /// <param name="contentPath"></param>
        /// <returns></returns>
        public static MvcHtmlString Style(this HtmlHelper html, string contentPath)
        {
            return VersionContent(html, "<link href=\"{0}\" rel=\"stylesheet\" type=\"text/css\">", contentPath);
        }

        private static MvcHtmlString VersionContent(this HtmlHelper html, string template, string contentPath)
        {
            var httpContenxt = html.ViewContext.HttpContext;
            //获取版本号
            string Value = DateTime.Now.ToString("yyyyMMddHHmmss");
            contentPath = UrlHelper.GenerateContentUrl(contentPath, httpContenxt) + "?v=" + Value;
            return MvcHtmlString.Create(string.Format(template, contentPath));
        }

    }
}
