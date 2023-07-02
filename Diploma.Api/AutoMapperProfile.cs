using AutoMapper;
using Diploma.Domain.Entities;
using Diploma.DTO;

namespace Diploma.Api
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Item, ItemDto>();
            CreateMap<Item, ItemDto>().ReverseMap();
            CreateMap<Category, CategoryDto>();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<ItemDto, SearchItemDto>();
            CreateMap<CartItem, CartItemDto>();
            CreateMap<User, CreateUserDto>();
            CreateMap<User, AuthenticateUserDto>();
        }
    }
}
