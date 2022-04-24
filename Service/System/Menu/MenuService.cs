using Admin.Core.Common.Output;

using Common.Extend;
using Common.Output;
using Common.Output.Input;

using Entity;

using Service.System.Menu.Dto;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Service.System.Menu
{
    public class MenuService : ServiceBase, IMenuService
    {

        public IResponseOutput GetMenuCategory(PagingInput<MenuCategoryPDto> input)
        {
            Expression<Func<menu, bool>> where = null;
            if (!string.IsNullOrWhiteSpace(input.Filter?.MenuName))
            {
                where = where.And(w => w.MenuName.Contains(input.Filter.MenuName));
            }
            if (!string.IsNullOrWhiteSpace(input.Filter?.MenuName))
            {
                where = where.And(w => w.SystemCoding.Equals(input.Filter.SystemCoding));
            }
            Expression<Func<menu, int>> orderby = o => o.Sorting;
            var query = context.menu.FindBy(where, input.page, input.limit, out int total, orderby);
            var list = query.ToList().Select(a =>
             {
                 var coding = context.systemfunction.Where(w => w.SystemCoding == a.SystemCoding).FirstOrDefault();
                 return new
                 {
                     Id = a.Id,
                     MenuName = a.MenuName,
                     SystemCoding = a.SystemCoding,
                     CodingName = coding.SystemCoding + "-" + coding.SystemName,
                     Sorting = a.Sorting,
                     Icon = a.Icon,
                     State = a.State
                 };
             });
            return ResponseOutput.Ok(list, total);
        }

        public IResponseOutput GetSystemCode()
        {
            var list = context.systemfunction.OrderByDescending(c => c.CreationTime).Select(m => new
            {
                Key = m.Id.ToString(),
                Value = m.SystemCoding + "-" + m.SystemName
            }).ToList();
            return ResponseOutput.Ok(list);
        }


        public IResponseOutput MenuCategroyAdd(MenuCategoryEditPDto input)
        {
            try
            {
                var menu = context.menu.Where(w => w.MenuName.Equals(input.MenuName) && w.SystemCoding.Equals(input.SystemCoding)).FirstOrDefault();
                if (menu != null)
                {
                    return ResponseOutput.NotOk("菜单类别名称已存在");
                }
                menu info = new menu
                {
                    MenuName = input.MenuName,
                    Menulevel = "1",
                    SystemCoding = input.SystemCoding,
                    Sorting = input.Sorting,
                    Icon = input.Icon,
                    CreationTime = DateTime.Now,
                    UpdateTime = DateTime.Now
                };
                context.menu.Add(info);
                context.SaveChanges();
                return ResponseOutput.Ok();
            }
            catch (Exception err)
            {
                return ResponseOutput.NotOk(err.Message);
            }
        }
        public IResponseOutput MenuCategroyUpdate(MenuCategoryEditPDto input)
        {
            try
            {
                var menuupdate = context.menu.Find(input.Id);
                if (menuupdate == null)
                {
                    return ResponseOutput.NotOk("菜单类别不存在！");
                }
                menuupdate.UpdateTime = DateTime.Now;
                menuupdate.Sorting = input.Sorting;
                menuupdate.MenuName = input.MenuName;
                menuupdate.SystemCoding = input.SystemCoding;
                context.SaveChanges();
                return ResponseOutput.Ok();
            }
            catch (Exception err)
            {
                return ResponseOutput.NotOk(err.Message);
            }
        }

        public IResponseOutput DeleteMenuCategroy(int id)
        {
            var menudelete = context.menu.Find(id);
            if (menudelete == null)
            {
                return ResponseOutput.NotOk("菜单类别不存在！");
            }
            var Parentmenu = context.menu.Where(w => w.ParentMenu == id).FirstOrDefault();
            if (Parentmenu != null)
            {
                return ResponseOutput.NotOk("该菜单下存在子菜单，不能删除");
            }
            context.menu.Remove(id);
            context.SaveChanges();
            return ResponseOutput.Ok();
        }

        [Obsolete]
        public IResponseOutput GetMenu(PagingInput<MenuPDto> input)
        {
            var parentmenu = input.Filter?.MenuName;
            Expression<Func<menu, bool>> where = null;
            where.And(w => w.ParentMenu.Equals(input.Filter.ParentMenu));
            if (parentmenu.NotNull())
            {
                where.And(w => w.MenuName.Contains(input.Filter.MenuName));
            }
            Expression<Func<menu, int>> orderby = o => o.Sorting;
            var query = context.menu.FindBy(where, input.page, input.limit, out int total, orderby);
            var list = query.ToList().Select(a =>
            {
                var parent = context.menu.Where(w => w.Id == a.ParentMenu).FirstOrDefault();
                return new
                {
                    Id = a.Id,
                    a.MenuName,
                    ParentMenuName = parent.MenuName,
                    a.MenuAddress,
                    a.Sorting,
                    a.State,
                    a.Icon
                };
            });
            return ResponseOutput.Ok(list, total);
        }

        public IResponseOutput MenuAdd(MenuEditPDto input)
        {
            try
            {
                var menus = context.menu.Where(m => m.MenuName.Equals(input.MenuName) && m.ParentMenu == input.ParentMenu).FirstOrDefault();
                if (menus != null)
                {
                    return ResponseOutput.NotOk("菜单名称已存在");
                }
                menu info = new menu
                {
                    MenuName = input.MenuName,
                    Menulevel = "2",
                    MenuAddress = input.MenuAddress,
                    SystemCoding = input.SystemCoding,
                    Sorting = input.Sorting,
                    Icon = input.Icon,
                    CreationTime = DateTime.Now,
                    UpdateTime = DateTime.Now
                };
                context.menu.Add(info);
                context.SaveChanges();
                return ResponseOutput.Ok();
            }
            catch (Exception err)
            {
                return ResponseOutput.NotOk(err.Message);
            }
        }

        public IResponseOutput MenuUpdate(MenuEditPDto input)
        {
            try
            {
                var menuupdate = context.menu.Find(input.Id);
                if (menuupdate == null)
                {
                    return ResponseOutput.NotOk("菜单不存在！");
                }
                menuupdate.Sorting = input.Sorting;
                menuupdate.MenuName = input.MenuName;
                menuupdate.Icon = input.Icon;
                menuupdate.SystemCoding = input.SystemCoding;
                menuupdate.CreationTime = DateTime.Now;
                context.SaveChanges();
                return ResponseOutput.Ok();
            }
            catch (Exception err)
            {
                return ResponseOutput.NotOk(err.Message);
            }
        }

        public IResponseOutput DeleteMenu(int id)
        {
            try
            {
                var menudelete = context.menu.Find(id);
                if (menudelete == null)
                {
                    return ResponseOutput.NotOk("菜单不存在！");
                }
                context.menu.Remove(id);
                context.SaveChanges();
                return ResponseOutput.Ok();
            }
            catch (Exception err)
            {
                return ResponseOutput.NotOk(err.Message);
            }
        }

        public IResponseOutput UpdateMenuZt(MenuUpdateZtPDto input)
        {
            try
            {
                var menudelete = context.menu.Find(input.Id);
                if (menudelete == null)
                {
                    return ResponseOutput.NotOk("菜单不存在！");
                }
                menudelete.State = input.State;
                menudelete.UpdateTime = DateTime.Now;
                context.SaveChanges();
                return ResponseOutput.Ok();
            }
            catch (Exception err)
            {
                return ResponseOutput.NotOk(err.Message);
            }
        }
    }
}
