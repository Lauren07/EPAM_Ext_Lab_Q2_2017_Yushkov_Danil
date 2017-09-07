using AutoMapper;
using BusinessLogicLayer.Models;
using DataAccessLayer.Entities;

namespace FileStorage.Profiles
{
    public class BllProfile : Profile
    {
        public BllProfile()
        {
            this.CreateMap<UserDTO, User>();
            this.CreateMap<FileDTO, File>().ForMember("UserId", opt => opt.MapFrom(x => x.User.Id));
            this.CreateMap<File, FileInfoDTO>();
            this.CreateMap<File, FileDTO>().ForMember(x => x.User, opt => opt.MapFrom(y => y));
            this.CreateMap<File, User>().ForMember(x => x.Id, opt => opt.MapFrom(y => y.UserId));
        }
    }
}