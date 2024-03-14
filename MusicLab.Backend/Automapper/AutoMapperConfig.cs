using AutoMapper;

namespace MusicLab.Backend.Automapper
{
    public static class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new RequestToDomain());
            });
        }
    }
}
