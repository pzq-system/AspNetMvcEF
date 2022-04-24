using Common.Output.Input;

using Service.System.Menu;
using Service.System.Menu.Dto;

using System;
using System.Web.Mvc;

using Web.Common;

namespace Web.Areas.system.Controllers
{
    public class MenuController : BaseController
    {
        Lazy<IMenuService> _menuService;

        public MenuController(Lazy<IMenuService> menuService)
        {
            _menuService = menuService;
        }

        public ActionResult GetMenuCategroy()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetMenuCategroy(PagingInput<MenuCategoryPDto> input)
        {
            return ResultJson(_menuService.Value.GetMenuCategory(input));
        }

        public ActionResult MenuCategroyEdit()
        {
            return View();
        }


        [HttpPost]
        public ActionResult MenuCategroyAdd(MenuCategoryEditPDto input)
        {
            return Json(_menuService.Value.MenuCategroyAdd(input));
        }


        [HttpPost]
        public ActionResult MenuCategroyUpdate(MenuCategoryEditPDto input)
        {
            return Json(_menuService.Value.MenuCategroyUpdate(input));
        }

        [HttpPost]
        public ActionResult GetSystemList()
        {
            return Json(_menuService.Value.GetSystemCode());
        }

        [HttpPost]
        public ActionResult DeleteMenuCategroy(int Id)
        {
            return Json(_menuService.Value.DeleteMenuCategroy(Id));
        }

        public ActionResult GetIcon()
        {
            return View();
        }

        public ActionResult GetMenu()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetMenu(PagingInput<MenuPDto> input)
        {
            return Json(_menuService.Value.GetMenu(input));
        }

        public ActionResult MenuEdit()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MenuAdd(MenuEditPDto input)
        {
            return Json(_menuService.Value.MenuAdd(input));
        }


        [HttpPost]
        public ActionResult MenuUpdate(MenuEditPDto input)
        {
            return Json(_menuService.Value.MenuUpdate(input));
        }

        [HttpPost]
        public ActionResult UpdateMenuZt(MenuUpdateZtPDto input)
        {
            return Json(_menuService.Value.UpdateMenuZt(input));
        }


    }
}