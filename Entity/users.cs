//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class users:BaseModel
    {
        int _id;
        public new int Id { get{ return _id; } set{ _id=value; base.Id = value; } }
        public string Useraccount { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string State { get; set; }
        public System.DateTime CreationTime { get; set; }
        public System.DateTime UpdateTime { get; set; }
        public System.DateTime PassUpdateTime { get; set; }
    }
}
