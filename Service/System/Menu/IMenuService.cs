using Common.Output;
using Common.Output.Input;

using Service.System.Menu.Dto;

namespace Service.System.Menu
{
    public interface IMenuService:IService
    {
       

        /// <summary>
        /// 查询菜单类别
        /// </summary>
        /// <returns></returns>
        IResponseOutput GetMenuCategory(PagingInput<MenuCategoryPDto> input);

        /// <summary>
        /// 查询系统编码
        /// </summary>
        /// <returns></returns>
        IResponseOutput GetSystemCode();

        /// <summary>
        /// 添加菜单类别
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        IResponseOutput MenuCategroyAdd(MenuCategoryEditPDto input);

        /// <summary>
        /// 编辑菜单类别
        /// </summary>
        /// <returns></returns>
        IResponseOutput MenuCategroyUpdate(MenuCategoryEditPDto input);

        /// <summary>
        /// 菜单类别删除
        /// </summary>
        /// <returns></returns>
        IResponseOutput DeleteMenuCategroy(int id);

        /// <summary>
        /// 查询菜单
        /// </summary>
        /// <returns></returns>
        IResponseOutput GetMenu(PagingInput<MenuPDto> input);

        /// <summary>
        /// 添加菜单
        /// </summary>
        /// <returns></returns>
        IResponseOutput MenuAdd(MenuEditPDto input);

        /// <summary>
        /// 编辑菜单
        /// </summary>
        /// <returns></returns>
        IResponseOutput MenuUpdate(MenuEditPDto input);

        /// <summary>
        /// 菜单删除
        /// </summary>
        /// <returns></returns>
        IResponseOutput DeleteMenu(int id);

        /// <summary>
        /// 修改菜单状态
        /// </summary>
        /// <returns></returns>
        IResponseOutput UpdateMenuZt(MenuUpdateZtPDto input);
    }
}
