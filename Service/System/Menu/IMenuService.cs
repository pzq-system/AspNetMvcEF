using Common.Output;
using Common.Output.Input;

using Model.System;

using Service.System.Menu.Input;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.System.Menu
{
    public interface IMenuService
    {
        /// <summary>
        /// 查询系统编码
        /// </summary>
        /// <returns></returns>
        IResponseOutput GetSystemCode();

        /// <summary>
        /// 查询菜单类别
        /// </summary>
        /// <returns></returns>
        IResponseOutput GetMenuCategory(PagingInput<MenuEntity> input);

        /// <summary>
        /// 添加菜单类别
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        IResponseOutput MenuCategroyAdd(MenuCategroyAddInput input);

        /// <summary>
        /// 编辑菜单类别
        /// </summary>
        /// <returns></returns>
        IResponseOutput MenuCategroyUpdate(MenuCategroyUpdateInput input);

        /// <summary>
        /// 菜单类别删除
        /// </summary>
        /// <returns></returns>
        IResponseOutput DeleteMenuCategroy(int id);

        /// <summary>
        /// 查询菜单
        /// </summary>
        /// <returns></returns>
        IResponseOutput GetMenu(PagingInput<MenuEntity> input);

        /// <summary>
        /// 添加菜单
        /// </summary>
        /// <returns></returns>
        IResponseOutput MenuAdd(MenuAddInput input);

        /// <summary>
        /// 编辑菜单
        /// </summary>
        /// <returns></returns>
        IResponseOutput MenuUpdate(MenuUpdateInput input);

        /// <summary>
        /// 菜单删除
        /// </summary>
        /// <returns></returns>
        IResponseOutput DeleteMenu(int id);

        /// <summary>
        /// 修改菜单状态
        /// </summary>
        /// <returns></returns>
        IResponseOutput UpdateMenuZt(MenuUpdateZtInput input);
    }
}
