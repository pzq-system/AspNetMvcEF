using Common.Extend;
using Common.Output;
using Common.Output.Input;

using Entity;

using Newtonsoft.Json.Linq;

using Service.System.Role.Dto;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Service.System.Role
{
    public class RoleService : ServiceBase, IRoleService
    {
        /// <summary>
        /// 获取菜单Json对象
        /// </summary>
        /// <returns></returns>
        public IResponseOutput GetMenu(MenuPDto input)
        {
            var qeruy = context.menu.Where(w => w.State == "1" && w.SystemCoding == input.SystemCoding).ToList();
            var parentmenu = qeruy.Where(w => w.ParentMenu == 0);
            List<Tree> trees = new List<Tree>();
            foreach (var item in parentmenu)
            {
                var menu = qeruy.Where(w => w.ParentMenu == item.Id);
                List<TreeItem> children = new List<TreeItem>();
                foreach (var submenu in menu)
                {
                    TreeItem treeItem = new TreeItem
                    {
                        title = submenu.MenuName,
                        field = "MenuID",
                        id = submenu.Id.ToString(),
                        spread = true,
                        @checked = input.Roles == null ? false : input.Roles.Contains(submenu.Id.ToString())
                    };
                    children.Add(treeItem);
                }
                Tree tree = new Tree
                {
                    title = item.MenuName,
                    field = "MenuID",
                    id = item.Id.ToString(),
                    spread = true,
                    children = children
                };
                trees.Add(tree);
            }
            return ResponseOutput.Ok(trees);
        }
        public IResponseOutput GetRole(PagingInput<RolePDto> input)
        {
            Expression<Func<role, bool>> where = null;
            if (!string.IsNullOrWhiteSpace(input.Filter?.SystemCoding))
            {
                where = where.And(w => w.SystemCoding.Equals(input.Filter.SystemCoding));
            }
            Expression<Func<role, DateTime>> orderby = o => o.CreationTime;
            var query = context.role.FindBy(where, input.page, input.limit, out int total, orderby, false);
            var list = query.ToList().Select(a =>
            {
                var coding = context.systemfunction.Where(w => w.SystemCoding == a.SystemCoding).FirstOrDefault();
                var rolemenu = context.rolemenu.Where(w => w.RoleId == a.RoleId).ToList();
                string menus = string.Empty;
                foreach (var item in rolemenu)
                {
                    menus = menus == "" ? "" : menus + ",";
                    menus += item.MenuId.ToString();
                }
                return new
                {
                    a.RoleId,
                    a.RoleName,
                    a.CreationTime,
                    CodingName = coding.SystemCoding + "-" + coding.SystemName,
                    a.SystemCoding,
                    MenuIds = menus
                };
            });
            return ResponseOutput.Ok(list, total);
        }

        public IResponseOutput RoleAdd(RolePEditDto input)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    if (input.RoleId == 0)
                    {
                        var roles = context.role.Where(w => w.RoleName == input.RoleName).FirstOrDefault();
                        if (roles != null)
                        {
                            return ResponseOutput.NotOk("角色已存在");
                        }
                        role info = new role();
                        info.SystemCoding = input.SystemCoding;
                        info.RoleName = input.RoleName;
                        info.Sorting = 1;
                        info.CreateUserName = "PZQ";
                        info.UpdateUserName = "";
                        info.CreationTime = DateTime.Now;
                        info.UpdateTime = DateTime.Now;
                        context.role.Add(info);
                        context.SaveChanges();
                        var rolemenuids = input.RoleMenuIds;
                        var ids = rolemenuids.Split(',');
                        foreach (var item in ids)
                        {
                            rolemenu rolemenu = new rolemenu
                            {
                                RoleId = info.RoleId,
                                MenuId = int.Parse(item),
                                CreateUserName = "",
                                CreationTime = DateTime.Now
                            };
                            context.rolemenu.Add(rolemenu);
                        }
                    }
                    else
                    {
                        var roles = context.role.Where(w => w.RoleId == input.RoleId).FirstOrDefault();
                        if (roles.RoleName != input.RoleName)
                        {
                            roles = context.role.Where(w => w.RoleName == input.RoleName).FirstOrDefault();
                            if (roles != null)
                            {
                                return ResponseOutput.NotOk("角色已存在");
                            }
                        }
                        roles.RoleName = input.RoleName;
                        roles.UpdateUserName = "PZQ";
                        roles.UpdateTime = DateTime.Now;
                        context.rolemenu.Remove(w => w.RoleId == roles.RoleId);
                        var rolemenuids = input.RoleMenuIds;
                        var ids = rolemenuids.Split(',');
                        foreach (var item in ids)
                        {
                            rolemenu rolemenu = new rolemenu
                            {
                                RoleId = roles.RoleId,
                                MenuId = int.Parse(item),
                                CreateUserName = "",
                                CreationTime = DateTime.Now
                            };
                            context.rolemenu.Add(rolemenu);
                        }
                    }
                    context.SaveChanges();
                    scope.Complete();//保存
                    scope.Dispose();//释放
                }
                return ResponseOutput.Ok();
            }
            catch (Exception err)
            {
                return ResponseOutput.NotOk(err.Message);
            }
        }

        public IResponseOutput RoleDelete(RoleDeletePDto input)
        {
            try
            {
                var role = context.role.Where(w => w.RoleId == input.RoleId).FirstOrDefault();
                if (role == null)
                {
                    return ResponseOutput.NotOk("角色不存在");
                }
                var userroels = context.userrole.Where(w => w.RoleId == input.RoleId).FirstOrDefault();
                if (userroels != null)
                {
                    return ResponseOutput.NotOk("角色已被用户使用，不能删除");
                }
                context.role.Remove(w => w.RoleId == input.RoleId);
                context.SaveChanges();
                return ResponseOutput.Ok();
            }
            catch (Exception err)
            {
                return ResponseOutput.NotOk(err.Message);
            }
        }

        public IResponseOutput GetUserRole(UserRolePDto input)
        {
            if (input.Selected.IsNull())
            {
                var query = context.role.FindAll().ToList();
                return ResponseOutput.Ok(query);
            }
            else
            {
                var user = context.users.Where(w => w.Useraccount == "pzq").FirstOrDefault();
                var userrole = context.userrole.Where(w => w.UsersId == user.Id);
                var roles = string.Empty;
                foreach (var item in userrole)
                {
                    roles = roles == "" ? "" : roles + ",";
                    roles += item.Id;
                }
                var query = context.role.Where(w => roles.Contains(w.Id.ToString()));
                return ResponseOutput.Ok(query);
            }

        }
    }
}
