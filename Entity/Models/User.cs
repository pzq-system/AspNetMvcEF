using System;
using System.Collections.Generic;

#nullable disable

namespace MySqEntity.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string Useraccount { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string State { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public DateTime PassUpdateTime { get; set; }
    }
}
