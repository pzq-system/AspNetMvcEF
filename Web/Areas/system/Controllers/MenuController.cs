using Common.Output.Input;

using Model.System;

using Service.System.Menu;
using Service.System.Menu.Input;

using System.Web.Mvc;

using Web.Common;

namespace Web.Areas.system.Controllers
{
    public class MenuController : BaseController
    {
        IMenuService _menuService;

        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        public ActionResult GetMenuCategroy()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetMenuCategroy(PagingInput<MenuEntity> input)
        {
            return ResultJson(_menuService.GetMenuCategory(input));
        }

        public ActionResult MenuCategroyEdit()
        {
            return View();
        }


        [HttpPost]
        public ActionResult MenuCategroyAdd(MenuCategroyAddInput input)
        {
            return Json(_menuService.MenuCategroyAdd(input));
        }


        [HttpPost]
        public ActionResult MenuCategroyUpdate(MenuCategroyUpdateInput input)
        {
            return Json(_menuService.MenuCategroyUpdate(input));
        }

        [HttpPost]
        public ActionResult GetSystemList()
        {
            return Json(_menuService.GetSystemCode());
        }

        [HttpPost]
        public ActionResult DeleteMenuCategroy(int Id)
        {
            return Json(_menuService.DeleteMenuCategroy(Id));
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
        public ActionResult GetMenu(PagingInput<MenuEntity> input)
        {
            return Json(_menuService.GetMenu(input));
        }

        public ActionResult MenuEdit()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MenuAdd(MenuAddInput input)
        {
            return Json(_menuService.MenuAdd(input));
        }


        [HttpPost]
        public ActionResult MenuUpdate(MenuUpdateInput input)
        {
            return Json(_menuService.MenuUpdate(input));
        }

        [HttpPost]
        public ActionResult UpdateMenuZt(MenuUpdateZtInput input)
        {
            return Json(_menuService.UpdateMenuZt(input));
        }


    }
}