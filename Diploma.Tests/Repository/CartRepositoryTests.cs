using AutoMapper;
using Diploma.BusinessLogic.Repositories.CartRepository;
using Diploma.BusinessLogic.Repositories.CategoryRepository;
using Diploma.DataAccess;
using Diploma.Domain.Entities;
using Diploma.DTO.Cart;
using FakeItEasy;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Diploma.Tests.Repository
{
    public class CartRepositoryTests
    {
        //private readonly IMapper _mapper;

        public CartRepositoryTests(/*IMapper mapper*/)
        {
            //_mapper = A.Fake<IMapper>();
        }

        public async Task<DataContext> GetDataContext()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var dataContext = new DataContext(options);
            dataContext.Database.EnsureCreated();
            return dataContext;
        }

        [Fact]
        public async void CartRespository_GetItemsFromCart_ReturnsTaskWithListOfCartItemDto()
        {
            //Arrange
            var dataContext = await GetDataContext();
            var cartRepository = new CartRepository(dataContext);
            var cartItems = new List<CartItem>
            {
                   new CartItem { UserId = 1, ItemId = 1, Quantity = 1 },
                   new CartItem { UserId = 1, ItemId = 2, Quantity = 5 },
                   new CartItem { UserId = 1, ItemId = 3, Quantity = 1 }
            };

            //Act
            var result = cartRepository.GetItemsFromCart(cartItems);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<Task<List<AddItemToCartDto>>>();
        }

            [Fact]
            public async void CartRepository_PutCartItemsToDatabase_ReturnsTaskWithListOfAddItemTOCartDto()
            {
                //Arrange
                int userId = 1;
                var dataContext = await GetDataContext();
                var cartRepository = new CartRepository(dataContext/*, _mapper*/);
                var cartItems = new List<CartItem>
            {
                   new CartItem { UserId = 1, ItemId = 1, Quantity = 1 },
                   new CartItem { UserId = 1, ItemId = 2, Quantity = 5 },
                   new CartItem { UserId = 1, ItemId = 3, Quantity = 1 }
            };
                //Act
                var result = cartRepository.PutCartItemsToDatabase(cartItems, userId);

                //Assert
                result.Should().NotBeNull();
                result.Should().BeOfType<Task<List<AddItemToCartDto>>>();
                //Clean up
                dataContext.Dispose();
            }

            [Fact]
            public async void CartRepository_GetNumberOfCartItems()
            {
                //Arrange
                int userId = 1;
                var dataContext = await GetDataContext();
                var cartRepository = new CartRepository(dataContext/*, _mapper*/);
                var cartItems = new List<CartItem>
            {
                   new CartItem { UserId = 1, ItemId = 1, Quantity = 1 },
                   new CartItem { UserId = 1, ItemId = 2, Quantity = 5 },
                   new CartItem { UserId = 1, ItemId = 3, Quantity = 1 }
            };
                //Act
                var result = cartRepository.GetNumberOfCartItems(userId);

                //Assert
                result.Should().NotBeNull();
                result.Should().BeOfType<Task<int>>();
                //Clean up
                dataContext.Dispose();
            }
        }
    }