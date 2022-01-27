using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.System
{
    [Table("role")]
    public partial class RoleEntity
    {
        public RoleEntity()
        {
            rolemenu = new HashSet<RolemenuEntity>();
            userrole = new HashSet<UserroleEntity>();
            CreationTime = DateTime.Now;
            UpdateTime = DateTime.Now;
        }
        [Key]
        public int RoleId { get; set; }
        public int SystemCoding { get; set; }
        public string RoleName { get; set; }
        public int Sorting { get; set; }
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime UpdateTime { get; set; }

        public virtual SystemfunctionEntity systemfunction { get; set; }

        public virtual ICollection<RolemenuEntity> rolemenu { get; set; }

        public virtual ICollection<UserroleEntity> userrole { get; set; }
    }
}
