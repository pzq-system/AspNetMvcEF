using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.System
{
    [Table("systemfunction")]
    public partial class SystemfunctionEntity
    {
        public SystemfunctionEntity()
        {
            dictionary = new HashSet<DictionaryEntity>();
            dictionarytype = new HashSet<DictionarytypeEntity>();
            menu = new HashSet<MenuEntity>();
            role = new HashSet<RoleEntity>();
            systemparameters = new HashSet<SystemparameterEntity>();
            CreationTime = DateTime.Now;
        }
        [Key]
        public int Id { get; set; }

        public string SystemCoding { get; set; }
        public string SystemName { get; set; }
        public string CreateUserName { get; set; }
        public DateTime CreationTime { get; set; }

        public virtual ICollection<DictionaryEntity> dictionary { get; set; }

        public virtual ICollection<DictionarytypeEntity> dictionarytype { get; set; }

        public virtual ICollection<RoleEntity> role { get; set; }

        public virtual ICollection<MenuEntity> menu { get; set; }

        public virtual ICollection<SystemparameterEntity> systemparameters { get; set; }
    }
}
