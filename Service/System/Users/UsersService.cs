using Common.Extend;
using Common.Helpers;
using Common.Output;
using Common.Output.Input;

using Entity;

using System;
using System.Linq;
using System.Linq.Expressions;

namespace Service.System.Users
{
    public class UsersService : ServiceBase, IUsersService
    {
        public IResponseOutput GetUsersList(PagingInput<UsersPDto> input)
        {

            Expression<Func<users, bool>> funcWhere = null;
            if (!string.IsNullOrWhiteSpace(input.Filter?.UserName))
            {
                funcWhere = funcWhere.And(c => c.Useraccount.Contains(input.Filter.UserName));
                funcWhere = funcWhere.Or(c => c.UserName.Contains(input.Filter.UserName));
            }
            Expression<Func<users, DateTime>> funcOrderBy = c => c.CreationTime;
            var list = context.users.FindBy(funcWhere, input.page, input.limit, out int total, funcOrderBy, false);
            return ResponseOutput.Ok(list, total);
        }

        public IResponseOutput Add(UsersEditPDto input)
        {
            try
            {
                var listuser = context.users.Where(u => u.Useraccount == input.Useraccount).FirstOrDefault();
                if (listuser != null)
                {
                    return ResponseOutput.NotOk("用户账号已存在");
                };
                users info = new users();
                info.Useraccount = input.Useraccount;
                info.UserName = input.UserName;
                info.Password = MD5Encrypt.Encrypt32("PZQ@123");
                info.CreationTime = DateTime.Now;
                info.UpdateTime = DateTime.Now;
                info.PassUpdateTime = DateTime.Now;
                info.State = "1";
                context.users.Add(info);
                context.SaveChanges();
                return ResponseOutput.Ok();
            }
            catch (Exception err)
            {
                return ResponseOutput.NotOk(err.Message);
            }
        }

        public IResponseOutput Update(UsersEditPDto input)
        {
            try
            {
                var user = context.users.FindById(input.Id);
                if (user == null)
                {
                    return ResponseOutput.NotOk("用户不存在！");
                }
                user.UserName = input.UserName;
                user.UpdateTime = DateTime.Now;
                context.SaveChanges();
                return ResponseOutput.Ok();
            }
            catch (Exception err)
            {
                return ResponseOutput.NotOk(err.Message);
            }
        }

        public IResponseOutput Delete(int Id)
        {
            try
            {
                var users = context.users.FindById(Id);
                if (users == null)
                {
                    return ResponseOutput.NotOk("用户不存在！");
                }
                context.users.Remove(Id);
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
