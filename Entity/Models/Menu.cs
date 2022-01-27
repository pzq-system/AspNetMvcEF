using System;
using System.Collections.Generic;

#nullable disable

namespace MySqEntity.Models
{
    public partial class Menu
    {
        public int Id { get; set; }
        public string MenuName { get; set; }
        public string MenuAddress { get; set; }
        public string Menulevel { get; set; }
        public int? ParentMenu { get; set; }
        public string SystemCoding { get; set; }
        public int Sorting { get; set; }
        public string Icon { get; set; }
        public string State { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
