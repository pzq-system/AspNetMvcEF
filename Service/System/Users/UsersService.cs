

using Common.Extend;
using Common.Helpers;
using Common.Output;
using Common.Output.Input;

using Model.System;

using Repository.System.Users;

using Service.System.Users.Input;
using Service.System.Users.OutPut;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.System.Users
{
    public class UsersService : BaseService, IUsersService
    {

        IUsersRepository _userService;
        public UsersService(IUsersRepository usersRepository)
        {
            _userService = usersRepository;
        }


        public IResponseOutput GetUsersList(PagingInput<UserEntity> input)
        {
            Expression<Func<UserEntity, bool>> funcWhere = null;
            if (!string.IsNullOrWhiteSpace(input.Filter?.UserName))
            {
                funcWhere = funcWhere.And(c => c.Useraccount.Contains(input.Filter.UserName));
                funcWhere = funcWhere.Or(c => c.UserName.Contains(input.Filter.UserName));
            }
            Expression<Func<UserEntity, DateTime>> funcOrderBy = c => c.CreationTime;
            List<UserEntity> userList = _userService.QueryPage(funcWhere, input.limit, input.page, funcOrderBy, out int total, false).ToList();
            if (userList.Count == 0)
            {
                return ResponseOutput.NotOk("暂无数据");
            }
            List<UsersListOutput> outputlist = Mapper.Map<List<UsersListOutput>>(userList);
            return ResponseOutput.Ok(outputlist, total);
        }

        public IResponseOutput Add(UsersAddInput usersAddInput)
        {
            var listuser = _userService.Query<UserEntity>(u => u.Useraccount == usersAddInput.Useraccount);
            if (listuser == null)
            {
                return ResponseOutput.NotOk("用户账号已存在");
            }
            if (usersAddInput.Password.IsNull())
            {
                usersAddInput.Password = "PZQ@123";
            }
            usersAddInput.Password = MD5Encrypt.Encrypt32(usersAddInput.Password);

            var entity = Mapper.Map<UserEntity>(usersAddInput);

            UserEntity user = _userService.Insert(entity);
            if (!(user?.Id > 0))
            {
                return ResponseOutput.NotOk("添加用户信息失败");
            }
            return ResponseOutput.Ok();
        }

        public IResponseOutput Update(UsersUpdateInput input)
        {
            var users = _userService.Find<UserEntity>(input.Id);
            if (!(users?.Id > 0))
            {
                return ResponseOutput.NotOk("用户不存在！");
            }

            Mapper.Map(input, users);
            _userService.Update(users);
            return ResponseOutput.Ok();
        }

        public IResponseOutput Delete(int Id)
        {
            var users = _userService.Find<UserEntity>(Id);
            if (users == null)
            {
                return ResponseOutput.NotOk("用户不存在！");
            }
            _userService.Delete<UserEntity>(Id);
            return ResponseOutput.Ok();
        }
    }
}
