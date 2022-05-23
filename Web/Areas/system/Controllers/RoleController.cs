using Common.Output.Input;

using Service.System.Role;
using Service.System.Role.Dto;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Web.Common;

namespace Web.Areas.system.Controllers
{
    public class RoleController : BaseController
    {

        Lazy<IRoleService> _roleserviceDto;

        public RoleController(Lazy<IRoleService> roleserviceDto)
        {
            _roleserviceDto = roleserviceDto;
        }

        public ActionResult GetRole()
        {
            return View();
        }

        /// <summary>
        /// 查询角色信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetRole(PagingInput<RolePDto> input)
        {
            return ResultJson(_roleserviceDto.Value.GetRole(input));
        }

        /// <summary>
        /// 查询所有的菜单
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetMenu(MenuPDto input)
        {
            return Json(_roleserviceDto.Value.GetMenu(input));
        }

        public ActionResult RoleEdit()
        {
            return View();
        }

        /// <summary>
        /// 编辑添加角色
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult RoleAdd(RolePEditDto input)
        {
            return Json(_roleserviceDto.Value.RoleAdd(input));
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult RoleDelete(RoleDeletePDto input) {
            return Json(_roleserviceDto.Value.RoleDelete(input));
        }

        /// <summary>
        /// 查询用户的角色信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetUserRole(UserRolePDto input) 
        {
            return Json(_roleserviceDto.Value.GetUserRole(input));
        }
    }
}