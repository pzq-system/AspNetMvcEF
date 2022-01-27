using System;
using System.Collections.Generic;

#nullable disable

namespace MySqEntity.Models
{
    public partial class Systemparameter
    {
        public int Id { get; set; }
        public string Encode { get; set; }
        public string EncodeName { get; set; }
        public string EncodeValue { get; set; }
        public string Description { get; set; }
        public string SystemCoding { get; set; }
        public string State { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
