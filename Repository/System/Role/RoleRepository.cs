using Repository.Base;

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.System.Role
{
    public class RoleRepository : BaseRepository, IRoleRepository
    {
        public RoleRepository(DbContext context) : base(context)
        {
        }
    }
}
