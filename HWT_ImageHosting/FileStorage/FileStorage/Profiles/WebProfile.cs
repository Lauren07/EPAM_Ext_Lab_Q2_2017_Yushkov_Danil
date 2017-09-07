using AutoMapper;
using BusinessLogicLayer.Models;
using DataAccessLayer.Entities;
using FileStorage.Models;

namespace FileStorage.Profiles
{
    public class WebProfile : Profile
    {
        public WebProfile()
        {
            this.CreateMap<UserRegistrationViewModel, UserDTO>();
            this.CreateMap<Role, RoleViewModel>();
            this.CreateMap<UserLoginViewModel, UserDTO>();
            this.CreateMap<FileLoadViewModel, FileDTO>().ForMember(x => x.Content, y => y.Ignore());
            this.CreateMap<FileInfoDTO, ImagePreviewViewModel>();
            this.CreateMap<FileDTO, ImageDetailsViewModel>().ForMember(x => x.UserName, opt => opt.MapFrom(y => y.User.Login));
            this.CreateMap<FileDTO, FileLoadViewModel>().ForMember(x => x.Content, y => y.Ignore());
        }
    }
}