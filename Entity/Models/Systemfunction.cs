using System;
using System.Collections.Generic;

#nullable disable

namespace MySqEntity.Models
{
    public partial class Systemfunction
    {
        public int Id { get; set; }
        public string SystemCoding { get; set; }
        public string SystemName { get; set; }
        public string CreateUserName { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
