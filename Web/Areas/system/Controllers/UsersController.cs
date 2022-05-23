
using Common.Output.Input;

using Service.System.Users;

using System;
using System.Web.Mvc;

using Web.Common;

namespace Web.Areas.system.Controllers
{
    public class UsersController : BaseController
    {

        Lazy<IUsersService> _userService;

        public UsersController(Lazy<IUsersService> userService)
        {
            _userService = userService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(PagingInput<UsersPDto> input)
        {
            return ResultJson(_userService.Value.GetUsersList(input));
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(UsersEditPDto users)
        {
            return Json(_userService.Value.Add(users));
        }

        public ActionResult Update()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Update(UsersEditPDto users)
        {
            return Json(_userService.Value.Update(users));
        }

        [HttpPost]

        public ActionResult Delete(int Id)
        {
            return Json(_userService.Value.Delete(Id));
        }

        public ActionResult UserRoleEdit() 
        {
            return View();
        }
    }
}