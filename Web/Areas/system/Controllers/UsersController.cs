
using Common.Output.Input;

using Model.System;

using Service.System.Users;
using Service.System.Users.Input;

using System.Web.Mvc;

using Web.Common;

namespace Web.Areas.system.Controllers
{
    public class UsersController : BaseController
    {

        IUsersService _userService;

        public UsersController(IUsersService userService)
        {
            _userService = userService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(PagingInput<UserEntity> input)
        {
            return ResultJson(_userService.GetUsersList(input));
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(UsersAddInput users)
        {
            return Json(_userService.Add(users));
        }

        public ActionResult Update()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Update(UsersUpdateInput users)
        {
            return Json(_userService.Update(users));
        }

        [HttpPost]

        public ActionResult Delete(int Id)
        {
            return Json(_userService.Delete(Id));
        }

    }
}