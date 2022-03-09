using Repository.Base;

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.System.Rolemenu
{
    public class RolemenuRepository : BaseRepository, IRolemenuRepository
    {
        public RolemenuRepository(DbContext context) : base(context)
        {
        }
    }
}
