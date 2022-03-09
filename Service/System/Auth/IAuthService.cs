using Common.Output;

using Service.System.Auth.Input;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.System.Auth
{
    public interface IAuthService
    {
        IResponseOutput Login(AuthLoginInput input);
    }
}
