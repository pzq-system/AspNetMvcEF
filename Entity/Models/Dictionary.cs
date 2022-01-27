using System;
using System.Collections.Generic;

#nullable disable

namespace MySqEntity.Models
{
    public partial class Dictionary
    {
        public int Id { get; set; }
        public int? DictionaryTypeId { get; set; }
        public string Coding { get; set; }
        public string Name { get; set; }
        public int? Sorting { get; set; }
        public string SystemCoding { get; set; }
        public string ExtensionDescription { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
