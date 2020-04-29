using AutoMapper;
using SS.API.Business.Dtos.User;
using SS.API.Business.Models;
using SS.API.Data.Models;

namespace SS.API.Helpers.MapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            //Business to Data
            CreateMap<UserBModel, Ssuser>()
                .ForMember(dest => dest.Id, opt =>
                    opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.UserId, opt =>
                    opt.MapFrom(src => src.UserId));

            //Data to Business            
            CreateMap<Ssuser, UserForDetailDto>()
                .ForMember(dest => dest.Created, opt =>
                    opt.MapFrom(src => src.CreatedDate));
            CreateMap<Ssuser, UserBModel>()
                .ForMember(dest => dest.UserId, opt =>
                    opt.MapFrom(src => src.Id));

            //Business to Dto
            CreateMap<UserBModel, UserForDetailDto>()
                .ForMember(dest => dest.Created, opt =>
                    opt.MapFrom(src => src.CreatedDate));

            //Dto to Data
            CreateMap<UserForRegisterDto, Ssuser>()
                .ForMember(dest => dest.DisplayName, opt =>
                    opt.MapFrom(src => src.FirstName));
            CreateMap<UserForDetailDto, Ssuser>()
                .ForMember(dest => dest.DisplayName, opt =>
                    opt.MapFrom(src => src.FirstName));
        }
    }
}