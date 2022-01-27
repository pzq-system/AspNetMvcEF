using System;
using System.Collections.Generic;

#nullable disable

namespace MySqEntity.Models
{
    public partial class Dictionarytype
    {
        public int Id { get; set; }
        public string DicType { get; set; }
        public string DicName { get; set; }
        public string SystemCoding { get; set; }
        public string Illustrate { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
