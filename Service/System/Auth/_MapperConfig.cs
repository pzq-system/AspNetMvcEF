using AutoMapper;

using Model.System;

using Service.System.Auth.Input;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.System.Auth
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<UserEntity, AuthLoginInput>();
        }
    }
}
