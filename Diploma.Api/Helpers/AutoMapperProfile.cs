using AutoMapper;
using Diploma.Domain.Entities;
using Diploma.DTO.Cart;
using Diploma.DTO.Category;
using Diploma.DTO.Item;
using Diploma.DTO.User;

namespace Diploma.Api.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Item, ItemDto>();
            CreateMap<Item, ItemDto>().ReverseMap();
            CreateMap<Item, AddItemToCartDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<ItemDto, SearchItemDto>();
            CreateMap<CartItem, CartItemDto>();
            CreateMap<User, CreateUserDto>();
            CreateMap<User, AuthenticateUserDto>();
            CreateMap<User, UserDto>();
        }
    }
}
