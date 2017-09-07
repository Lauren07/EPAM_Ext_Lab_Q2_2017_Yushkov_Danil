using AutoMapper;
using FileStorage.Profiles;

namespace FileStorage.App_Start
{
    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile(new BllProfile());
                cfg.AddProfile(new WebProfile());
            });
        }
    }
}