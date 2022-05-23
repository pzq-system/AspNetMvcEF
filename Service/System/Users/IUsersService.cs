using Common.Output;
using Common.Output.Input;

using Entity;

namespace Service.System.Users
{
    public interface IUsersService : IService
    {
        /// <summary>
        /// 查询用户信息列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        IResponseOutput GetUsersList(PagingInput<UsersPDto> input);
        /// <summary>
        /// 新增用户信息
        /// </summary>
        /// <param name="usersEntity"></param>
        /// <returns></returns>
        IResponseOutput Add(UsersEditPDto usersEntity);
        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="usersEntity"></param>
        /// <returns></returns>
        IResponseOutput Update(UsersEditPDto usersEntity);
        /// <summary>
        /// 删除用户信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        IResponseOutput Delete(int Id);
        /// <summary>
        /// 查询所有的角色信息
        /// </summary>
        /// <returns></returns>
        //IResponseOutput GetRole();
    }
}
