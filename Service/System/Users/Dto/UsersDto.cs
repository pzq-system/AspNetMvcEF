using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.System.Users
{
    public class UsersEditPDto
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
        ///状态 0 无效 1 有效 
        /// </summary>
        public string State { get; set; }

        /// <summary>
        ///创建时间 
        /// </summary>
        public DateTime CreationTime { get; set; }
    }

    public class UsersPDto
    {
        public string UserName { get; set; } = "";
    }
}
