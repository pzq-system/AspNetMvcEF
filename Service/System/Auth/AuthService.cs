using Common.Helpers;
using Common.Output;

using Service.System.Auth.Dto;

using System;
using System.Linq;
using System.Web;

namespace Service.System.Auth
{
    public class AuthService : ServiceBase, IAuthService
    {

        public IResponseOutput Login(AuthLoginPDto input)
        {
            string useraccount = input.Useraccount.Trim();
            string password = input.Password.Trim();
            if (HttpContext.Current.Session["LoginCode"] == null)
            {
                return ResponseOutput.NotOk("验证码过期，请刷新验证码", "0030");
            }
            else
            {
                if (input.VerifyCode.ToUpper() != HttpContext.Current.Session["LoginCode"].ToString())
                {
                    return ResponseOutput.NotOk("验证码错误，请重新输入", "0030");
                }
            }
            password = MD5Encrypt.Encrypt32(input.Password);
            var query = context.user.Where(w => w.Useraccount.Equals(input.Useraccount)).FirstOrDefault();
            if (query == null)
            {
                return ResponseOutput.NotOk("账号或密码错误！");
            }
            if (password != query.Password)
            {
                return ResponseOutput.NotOk("账号或密码错误！");
            }
            SessionUser sessionUser = new SessionUser()
            {
                Useraccount = query.Useraccount,
                UserName = query.UserName
            };
            RequestSession.AddSessionUser(sessionUser);
            return ResponseOutput.Ok();
        }
    }
}
