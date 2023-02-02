using AutoMapper;
using BLL.Models;
using UI.ViewModels;

namespace UI.Mapper.Profiles
{
    public class ApiToBusinessModelMapperProfile : Profile
    {
        public ApiToBusinessModelMapperProfile()
        {
            CreateMap<UserModel, RegisterViewModel>()
                .ReverseMap();
            CreateMap<UserModel, LoginViewModel>()
                .ReverseMap();
            CreateMap<ProductModel, ProductCreationViewModel>()
                .ReverseMap();
        }
    }
}
