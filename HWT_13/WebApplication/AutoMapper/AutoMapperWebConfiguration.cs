using AutoMapper;
using WebApplication.AutoMapper.Profiles;

namespace WebApplication.Modules
{
    public static class AutoMapperWebConfiguration//todo pn обычно конфиг автомаппера выносят в App_Start к другим конфигам. Но и так пойдет.
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