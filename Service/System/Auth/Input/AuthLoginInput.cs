using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.System.Auth.Input
{
    public class AuthLoginInput
    {
        public string Useraccount { get; set; }

        public string Password { get; set; }

        public string VerifyCode { get; set; }
    }
}
