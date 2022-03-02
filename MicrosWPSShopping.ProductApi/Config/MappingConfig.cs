using AutoMapper;
using MicrosWPSShopping.ProductApi.Data.ValueObjects;
using MicrosWPSShopping.ProductApi.Model;

namespace MicrosWPSShopping.ProductApi.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config=>
            {
                config.CreateMap<ProductVo, Product>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
