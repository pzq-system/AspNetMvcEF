using Common.Output;
using Common.Output.Input;

using Entity;

namespace Service.System.Users
{
    public interface IUsersService : IService
    {
        IResponseOutput GetUsersList(PagingInput<UsersPDto> input);

        IResponseOutput Add(UsersEditPDto usersEntity);

        IResponseOutput Update(UsersEditPDto usersEntity);

        IResponseOutput Delete(int Id);
    }
}
