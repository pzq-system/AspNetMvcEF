using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.System
{
    [Table("rolemenu")]
    public partial class RolemenuEntity
    {
        public RolemenuEntity()
        {
            CreationTime = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int MenuId { get; set; }
        public string CreateUserName { get; set; }
        public DateTime CreationTime { get; set; }

        public virtual MenuEntity menu { get; set; }

        public virtual RoleEntity role { get; set; }
    }
}
