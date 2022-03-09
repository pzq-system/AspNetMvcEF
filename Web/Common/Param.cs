using Service;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Common
{
    public class Param
    {

        /// <summary>
        /// 用户Session 账号
        /// </summary>
        public static string sessionUseraccount => RequestSession.GetSessionUserInfo.Useraccount;

        /// <summary>
        /// 用户Session 用户名
        /// </summary>
        public static string sessionUserName => RequestSession.GetSessionUserInfo.UserName;

    }
}