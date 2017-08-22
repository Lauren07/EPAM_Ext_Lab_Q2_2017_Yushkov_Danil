using AutoMapper;
using WebApplication.AutoMapper.Profiles;

namespace WebApplication.Modules
{
    public static class AutoMapperWebConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile(new WebProfile());
                cfg.AddProfile(new BllProfile());
            });
        }
    }
}