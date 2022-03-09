using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Service
{
    public class SessionUser
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string Useraccount { get; set; } = string.Empty;

        /// <summary>
        /// 姓名
        /// </summary>
        public string UserName { get; set; } = string.Empty;
    }
}