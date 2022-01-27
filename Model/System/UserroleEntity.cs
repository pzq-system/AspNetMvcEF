using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.System
{
    [Table("userrole")]
    public partial class UserroleEntity
    {
        public UserroleEntity()
        {
            CreationTime = DateTime.Now;
        }
        [Key]
        public int Id { get; set; }
        public int? UsersId { get; set; }
        public int? RoleId { get; set; }
        public string CreateUserName { get; set; }
        public DateTime CreationTime { get; set; }
        public virtual RoleEntity role { get; set; }
        public virtual UserEntity users { get; set; }
    }
}
