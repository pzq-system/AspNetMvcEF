using Common.Output;
using Common.Output.Input;

using Service.System.Role.Dto;

namespace Service.System.Role
{
    public interface IRoleService : IService
    {
        /// <summary>
        /// 获取菜单Json对象
        /// </summary>
        /// <returns></returns>
        IResponseOutput GetMenu(MenuPDto input);

        IResponseOutput GetRole(PagingInput<RolePDto> input);

        IResponseOutput RoleAdd(RolePEditDto input);

        IResponseOutput RoleDelete(RoleDeletePDto input);

        IResponseOutput GetUserRole(UserRolePDto input);
    }
}
