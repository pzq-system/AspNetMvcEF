using Admin.Core.Common.Output;

using Common.Extend;
using Common.Output;
using Common.Output.Input;

using Model.System;

using Repository.System.Menu;
using Repository.System.Systemfunction;

using Service.System.Menu.Input;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Service.System.Menu
{
    public class MenuService : BaseService, IMenuService
    {
        IMenuRepository _menuService;
        ISystemfunctionRepository _systemfunctionService;
        public MenuService(IMenuRepository menuRepository, ISystemfunctionRepository systemfunctionRepository)
        {
            _menuService = menuRepository;
            _systemfunctionService = systemfunctionRepository;
        }

        public IResponseOutput GetMenuCategory(PagingInput<MenuEntity> input)
        {
            var menuname = input.Filter?.MenuName;
            var systemcode = input.Filter?.SystemCoding;
            var list = from a in _menuService.Set<MenuEntity>()
                       join b in _menuService.Set<SystemfunctionEntity>() on a.SystemCoding equals b.Id
                       where a.Menulevel == "1"
                       orderby a.Sorting ascending
                       select new
                       {
                           Id = a.Id,
                           MenuName = a.MenuName,
                           SystemCoding = a.SystemCoding,
                           CodingName = b.SystemCoding + "-" + b.SystemName,
                           Sorting = a.Sorting,
                           Icon = a.Icon,
                           State = a.State
                       };
            if (menuname.NotNull())
            {
                list = list.Where(m => m.MenuName.Contains(menuname));
            }
            if (systemcode != null && systemcode != 0)
            {
                list = list.Where(m => m.SystemCoding.Equals((int)systemcode));
            }
            int toTal = list.Count();
            var outlist = list.Skip((input.page - 1) * input.limit).Take(input.limit).ToList();
            return ResponseOutput.Ok(outlist, toTal);
        }

        public IResponseOutput GetSystemCode()
        {
            List<OptionOutput> list = _systemfunctionService.Query<SystemfunctionEntity, DateTime>(null, c => c.CreationTime).Select(m => new OptionOutput
            {
                Key = m.Id.ToString(),
                Value = m.SystemCoding + "-" + m.SystemName
            }).ToList();
            return ResponseOutput.Ok(list);
        }


        public IResponseOutput MenuCategroyAdd(MenuCategroyAddInput input)
        {
            var listmenu = _menuService.Query<MenuEntity>(m => m.MenuName.Equals(input.MenuName) && m.SystemCoding.Equals(input.SystemCoding));
            if (listmenu != null)
            {
                return ResponseOutput.NotOk("菜单类别名称已存在");
            }
            var entity = Mapper.Map<MenuEntity>(input);
            MenuEntity menuEntity = _menuService.Insert(entity);
            if (!(menuEntity.Id > 0))
            {
                return ResponseOutput.NotOk("添加菜单类别失败");
            }
            return ResponseOutput.Ok();

        }
        public IResponseOutput MenuCategroyUpdate(MenuCategroyUpdateInput input)
        {
            var menu = _menuService.Find<MenuEntity>(input.Id);
            if (!(menu?.Id > 0))
            {
                return ResponseOutput.NotOk("菜单类别不存在！");
            }
            input.UpdateTime = DateTime.Now;
            Mapper.Map(input, menu);
            _menuService.Update(menu);
            return ResponseOutput.Ok();
        }

        public IResponseOutput DeleteMenuCategroy(int id)
        {
            var menucategroy = _menuService.Find<MenuEntity>(id);
            if (menucategroy == null)
            {
                return ResponseOutput.NotOk("该菜单类别为空，不能删除");
            }

            var Parentmenu = _menuService.Query<MenuEntity>(m => m.ParentMenu == id);
            if (Parentmenu != null)
            {
                return ResponseOutput.NotOk("该菜单下存在子菜单，不能删除");
            }
            _menuService.Delete<MenuEntity>(id);
            return ResponseOutput.Ok();
        }

        [Obsolete]
        public IResponseOutput GetMenu(PagingInput<MenuEntity> input)
        {
            var parentmenu = input.Filter?.ParentMenu;
            var menuname = input.Filter?.MenuName;
            var list = from t in _menuService.Set<MenuEntity>()
                       join t1 in _menuService.Set<MenuEntity>() on t.ParentMenu equals t1.Id
                       where t.ParentMenu == parentmenu
                       orderby t.Sorting ascending
                       select new
                       {
                           t.Id,
                           t.MenuName,
                           ParentMenuName = t1.MenuName,
                           t.MenuAddress,
                           t.Sorting,
                           t.State,
                           t.Icon
                       };

            if (menuname.NotNull())
            {
                list = list.Where(m => m.MenuName.Contains(menuname));
            }
            int total = list.Count();
            var outlist = list.Skip((input.page - 1) * input.limit).Take(input.limit).ToList();
            return ResponseOutput.Ok(outlist, total);
        }

        public IResponseOutput MenuAdd(MenuAddInput input)
        {
            var listmenu = _menuService.Query<MenuEntity>(m => m.MenuName.Equals(input.MenuName) && m.ParentMenu == input.ParentMenu);
            if (listmenu != null)
            {
                return ResponseOutput.NotOk("菜单名称已存在");
            }
            input.MenuAddress = HttpUtility.UrlEncode(input.MenuAddress);
            var entity = Mapper.Map<MenuEntity>(input);
            MenuEntity menuEntity = _menuService.Insert(entity);
            if (!(menuEntity.Id > 0))
            {
                return ResponseOutput.NotOk("添加菜单失败");
            }
            return ResponseOutput.Ok();
        }

        public IResponseOutput MenuUpdate(MenuUpdateInput input)
        {
            var menu = _menuService.Find<MenuEntity>(input.Id);
            if (!(menu?.Id > 0))
            {
                return ResponseOutput.NotOk("菜单不存在！");
            }
            input.MenuAddress = HttpUtility.UrlEncode(input.MenuAddress);
            input.UpdateTime = DateTime.Now;
            Mapper.Map(input, menu);
            _menuService.Update(menu);
            return ResponseOutput.Ok();
        }

        public IResponseOutput DeleteMenu(int id)
        {
            var menucategroy = _menuService.Find<MenuEntity>(id);
            if (menucategroy == null)
            {
                return ResponseOutput.NotOk("该菜单为空，不能删除");
            }
            _menuService.Delete<MenuEntity>(id);
            return ResponseOutput.Ok();
        }

        public IResponseOutput UpdateMenuZt(MenuUpdateZtInput input)
        {
            var menu = _menuService.Find<MenuEntity>(input.Id);
            if (!(menu?.Id > 0))
            {
                return ResponseOutput.NotOk("菜单不存在！");
            }
            input.UpdateTime = DateTime.Now;
            Mapper.Map(input, menu);
            _menuService.Update(menu);
            return ResponseOutput.Ok();
        }
    }
}
