using Repository.Base;

using System.Data.Entity;

namespace Repository.System.Users
{
    public class UsersRepository : BaseRepository, IUsersRepository
    {
        public UsersRepository(DbContext context) : base(context)
        {
        }
    }
}
