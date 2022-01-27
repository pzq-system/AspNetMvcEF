using AutoMapper;

using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;

namespace Service
{
    public abstract class BaseService : IBaseService
    {
        private MapperConfiguration _mapper;

        public BaseService()
        {
            //初始化配置AutoMapper
            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddMaps("Service");
            });
        }

        /// <summary>
        /// 映射
        /// </summary>
        public IMapper Mapper => _mapper.CreateMapper();


    }
}