using Common.Output;
using Common.Output.Input;

using Model.System;

using Service.System.Users.Input;

namespace Service.System.Users
{
    public interface IUsersService
    {
        IResponseOutput GetUsersList(PagingInput<UserEntity> input);

        IResponseOutput Add(UsersAddInput usersEntity);

        IResponseOutput Update(UsersUpdateInput usersEntity);

        IResponseOutput Delete(int Id);
    }
}
