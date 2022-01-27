using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.System
{
    [Table("dictionarytype")]
    public partial class DictionarytypeEntity
    {
        public DictionarytypeEntity()
        {
            dictionary = new HashSet<DictionaryEntity>();
            CreationTime = DateTime.Now;
            UpdateTime = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }
        public string DicType { get; set; }
        public string DicName { get; set; }
        public int SystemCoding { get; set; }
        public string Illustrate { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime UpdateTime { get; set; }

        public virtual ICollection<DictionaryEntity> dictionary { get; set; }

        public virtual SystemfunctionEntity systemfunction { get; set; }
    }
}
