using System;

namespace Service.System.Menu.Input
{
    public class MenuUpdateZtInput
    {
        /// <summary>
        ///菜单ID 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdateTime { get; set; }
    }
}
