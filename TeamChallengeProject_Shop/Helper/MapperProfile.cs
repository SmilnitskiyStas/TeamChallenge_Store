using AutoMapper;
using TeamChallengeProject_Shop.Models;
using TeamChallengeProject_Shop.Models.DTOs;

namespace TeamChallengeProject_Shop.Helper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Store, StoreDto>();
            CreateMap<StoreDto, Store>();
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();
        }
    }
}
