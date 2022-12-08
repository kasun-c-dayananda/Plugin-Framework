using AutoMapper;

namespace Plugin_Framework.DbContexts
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                
            });

            return mappingConfig;
        }
    }
}
