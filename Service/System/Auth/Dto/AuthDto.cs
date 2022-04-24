namespace Service.System.Auth.Dto
{
    public class AuthLoginPDto
    {
        /// <summary>
        /// 账号
        /// </summary>
        public string Useraccount { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 验证码
        /// </summary>
        public string VerifyCode { get; set; }
    }
}
