using AutoMapper;
using BLL.Models;
using DAL.Models;

namespace BLL.Mapper.Profiles
{
    public class EntityToBusinessModelMapperProfile : Profile
    {
        public EntityToBusinessModelMapperProfile()
        {
            CreateMap<Product, ProductModel>()
                .ReverseMap();

            CreateMap<User, UserModel>()
                .ReverseMap();
        }
    }
}
