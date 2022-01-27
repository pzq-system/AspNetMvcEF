using System;

namespace Service.System.Users.Input
{
    public class UsersUpdateInput
    {
        /// <summary>
        ///用户ID 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///用户账号 
        /// </summary>
        public string Useraccount { get; set; }

        /// <summary>
        ///用户名字 
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdateTime { get; set; } = DateTime.Now;
    }
}
