using AutoMapper;
using GamerForumWeb.Core.MapperConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameForumWeb.Tests.Moks
{
    public class MapperMock
    {
        public static IMapper Instance
        {
            get
            {
                MapperConfiguration mapperConfiguration =
                    new MapperConfiguration(config =>
                    {
                        config.AddProfile<MappingProfile>();
                    });

                return new Mapper(mapperConfiguration);
            }
        }
    }
}
