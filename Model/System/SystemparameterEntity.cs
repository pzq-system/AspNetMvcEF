using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.System
{
    [Table("systemparameter")]
    public partial class SystemparameterEntity
    {
        public SystemparameterEntity()
        {
            State = "1";
            CreationTime = DateTime.Now;
            UpdateTime = DateTime.Now;
        }
        [Key]
        public int Id { get; set; }
        public string Encode { get; set; }
        public string EncodeName { get; set; }
        public string EncodeValue { get; set; }
        public string Description { get; set; }
        public int SystemCoding { get; set; }
        public string State { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public virtual SystemfunctionEntity systemfunction { get; set; }
    }
}
