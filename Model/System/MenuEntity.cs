using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.System
{
    [Table("menu")]
    public partial class MenuEntity
    {
        public MenuEntity()
        {
            rolemenu = new HashSet<RolemenuEntity>();
            CreationTime = DateTime.Now;
            UpdateTime = DateTime.Now;
            State = "1";
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string MenuName { get; set; }
        public string MenuAddress { get; set; }
        public string Menulevel { get; set; }
        public int? ParentMenu { get; set; }
        public int SystemCoding { get; set; }
        public int Sorting { get; set; }
        public string Icon { get; set; }

        public string State { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime UpdateTime { get; set; }

        public virtual SystemfunctionEntity systemfunction { get; set; }

        public virtual ICollection<RolemenuEntity> rolemenu { get; set; }
    }
}
