using System;
using System.Collections.Generic;

#nullable disable

namespace MySqEntity.Models
{
    public partial class Role
    {
        public int RoleId { get; set; }
        public string SystemCoding { get; set; }
        public string RoleName { get; set; }
        public int Sorting { get; set; }
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
