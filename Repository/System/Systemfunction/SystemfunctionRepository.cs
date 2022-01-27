using Repository.Base;

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.System.Systemfunction
{
    public class SystemfunctionRepository : BaseRepository, ISystemfunctionRepository
    {
        public SystemfunctionRepository(DbContext context) : base(context)
        {
        }
    }
}
