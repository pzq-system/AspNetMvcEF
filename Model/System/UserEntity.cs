using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.System
{
    [Table("users")]
    public partial class UserEntity
    {
        public UserEntity()
        {
            userrole = new HashSet<UserroleEntity>();
            CreationTime = DateTime.Now;
            UpdateTime = DateTime.Now;
            PassUpdateTime = DateTime.Now;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Useraccount { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DefaultValue("1")]
        public string State { get; set; }

        public DateTime CreationTime { get; set; }

        public DateTime UpdateTime { get; set; }

        public DateTime PassUpdateTime { get; set; }

        public virtual ICollection<UserroleEntity> userrole { get; set; }
    }
}
