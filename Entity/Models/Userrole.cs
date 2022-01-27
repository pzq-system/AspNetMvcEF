using System;
using System.Collections.Generic;

#nullable disable

namespace MySqEntity.Models
{
    public partial class Userrole
    {
        public int Id { get; set; }
        public int? UsersId { get; set; }
        public int? RoleId { get; set; }
        public string CreateUserName { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
