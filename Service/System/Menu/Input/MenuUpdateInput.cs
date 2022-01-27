using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.System.Menu.Input
{
    public class MenuUpdateInput
    {
        /// <summary>
        ///菜单ID 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///菜单名称 
        /// </summary>
        public string MenuName { get; set; }

        /// <summary>
        ///系统编码 
        /// </summary>
        public string SystemCoding { get; set; }

        /// <summary>
        ///系统菜单地址 
        /// </summary>
        public string MenuAddress { get; set; }
        /// <summary>
        /// 父菜单编码
        /// </summary>
        public int? ParentMenu { get; set; }

        /// <summary>
        /// 菜单级别
        /// </summary>
        public string Menulevel { get; set; } = "2";
        /// <summary>
        ///排序 
        /// </summary>
        public int? Sorting { get; set; }

        /// <summary>
        ///菜单图标 
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdateTime { get; set; }
    }
}
