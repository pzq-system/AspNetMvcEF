using Common.Extend;
using Common.Helpers;
using Common.Output;

using Model.System;

using Repository.System.Users;

using Service.System.Auth.Input;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Service.System.Auth
{
    public class AuthService : BaseService, IAuthService
    {
        IUsersRepository _usersRepository;
        public AuthService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }
        public IResponseOutput Login(AuthLoginInput input)
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
            UserEntity user = null;
            user = _usersRepository.Query<UserEntity>(c => c.Useraccount.Equals(input.Useraccount));
            if (!(user?.Id > 0))
            {
                return ResponseOutput.NotOk("账号输入有误!");
            }
            password = MD5Encrypt.Encrypt32(input.Password);
            if (password != user.Password)
            {
                return ResponseOutput.NotOk("密码输入有误！");
            }

            SessionUser sessionUser = new SessionUser()
            {
                Useraccount = user.Useraccount,
                UserName = user.UserName
            };
            RequestSession.AddSessionUser(sessionUser);
            return ResponseOutput.Ok();
        }
    }
}
