using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.System
{
    [Table("dictionary")]
    public partial class DictionaryEntity
    {
        public DictionaryEntity()
        {
            CreationTime = DateTime.Now;
            UpdateTime = DateTime.Now;
        }
        [Key]
        public int Id { get; set; }
        public int? DictionaryTypeId { get; set; }
        public string Coding { get; set; }
        public string Name { get; set; }
        public int? Sorting { get; set; }
        public int SystemCoding { get; set; }
        public string ExtensionDescription { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime UpdateTime { get; set; }

        public virtual DictionarytypeEntity dictionarytype { get; set; }

        public virtual SystemfunctionEntity systemfunction { get; set; }
    }
}
