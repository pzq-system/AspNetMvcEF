using AutoMapper;

using Model.System;

using Service.System.Users.Input;
using Service.System.Users.OutPut;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.System.Users
{

    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            //新增
            CreateMap<UsersAddInput, UserEntity>();

            CreateMap<UsersUpdateInput, UserEntity>();

            CreateMap<UserEntity, UsersListOutput>();
        }
    }
}
