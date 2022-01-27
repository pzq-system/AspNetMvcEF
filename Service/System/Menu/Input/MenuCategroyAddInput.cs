using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.System.Menu.Input
{
    public class MenuCategroyAddInput
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
        public int SystemCoding { get; set; }

        /// <summary>
        /// 菜单级别
        /// </summary>
        public string Menulevel { get; set; } = "1";
        /// <summary>
        ///排序 
        /// </summary>
        public int Sorting { get; set; }

        /// <summary>
        ///菜单图标 
        /// </summary>
        public string Icon { get; set; }

    }
}
