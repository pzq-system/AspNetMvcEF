using AutoMapper;

using Model.System;

using Service.System.Menu.Input;

namespace Service.System.Menu
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<MenuCategroyAddInput, MenuEntity>();

            CreateMap<MenuCategroyUpdateInput, MenuEntity>();

            CreateMap<MenuAddInput, MenuEntity>();

            CreateMap<MenuUpdateInput, MenuEntity>();

            CreateMap<MenuUpdateZtInput, MenuEntity>();
        }

    }
}
