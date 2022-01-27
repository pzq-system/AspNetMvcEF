using Repository.Base;

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.System.Menu
{
    public class MenuRepository : BaseRepository, IMenuRepository
    {
        public MenuRepository(DbContext context) : base(context)
        {
        }
    }
}
