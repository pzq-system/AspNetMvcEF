using Newtonsoft.Json.Linq;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.System.Role.Dto
{
    public class RolePDto
    {
        public string SystemCoding { get; set; }
    }

    public class RolePEditDto
    {
        public int RoleId { get; set; }

        public string SystemCoding { get; set; }

        public string RoleName { get; set; }

        public string RoleMenuIds { get; set; }
    }

    public class Tree
    {
        public string title { get; set; }
        public string field { get; set; }
        public string id { get; set; }
        public bool spread { get; set; }
        public List<TreeItem> children { get; set; }
    }
    public class TreeItem
    {
        public string title { get; set; }
        public string field { get; set; }
        public string id { get; set; }
        public bool spread { get; set; }
        public bool @checked { get; set; }
    }
    /// <summary>
    /// 查询菜单
    /// </summary>
    public class MenuPDto
    {
        public string SystemCoding { get; set; }
        public string Roles { get; set; }
    }

    public class RoleDeletePDto
    {
        public int RoleId { get; set; }
    }

    /// <summary>
    /// 查询用户角色入参
    /// </summary>
    public class UserRolePDto
    {
        public string Selected { get; set; }
    }
}
