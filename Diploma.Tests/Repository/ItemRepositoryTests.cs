using AutoMapper;
using Diploma.BusinessLogic.Repositories.ItemRepository;
using Diploma.DataAccess;
using Diploma.Domain.Entities;
using Diploma.DTO;
using FakeItEasy;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace Diploma.Tests.Repository
{
    public class ItemRepositoryTests
    {
        private readonly IMapper _mapper;
        public ItemRepositoryTests()
        {
            _mapper = A.Fake<IMapper>();
        }

        public async Task<DataContext> GetDataContext()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var dataContext = new DataContext(options);
            dataContext.Database.EnsureCreated();
            if (await dataContext.Items.CountAsync() <= 0)
            {
                for (int i = 0; i < 10; i++)
                {
                    dataContext.Items.Add(
                        new Item()
                        {
                            Name = "Lalala",
                            Description = "lalala",
                            ImageUrl = "https://images.unsplash.com/photo-1605020420620-20c943cc4669?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTF8fGd1aXRhcnxlbnwwfHwwfHx8MA%3D%3D&w=1000&q=80",
                            CategoryId = 1,
                            Price = 736,
                        });
                    await dataContext.SaveChangesAsync();
                }
            }
            return dataContext;
        }
        [Fact]
        public async void ItemRepository_GetItems_ReturnsTaskWithListOfItemDtos()
        {
            //Arrange
            var dataContext = await GetDataContext();
            var itemRepository = new ItemRepository(dataContext, _mapper);
            var items = A.Fake<ICollection<Item>>();
            var itemsDto = A.Fake<List<ItemDto>>();
            A.CallTo(() => _mapper.Map<List<ItemDto>>(items)).Returns(itemsDto);

            //Act
            var result = itemRepository.GetItems();

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<Task<List<ItemDto>>>();
        }

        [Fact]
        public async void ItemRepository_GetItem_ReturnsTaskWithItemDto()
        {
            //Arrange
            int itemId = 1;
            var dataContext = await GetDataContext();
            var itemRepository = new ItemRepository(dataContext, _mapper);
            var item = A.Fake<Item>();
            var itemDto = A.Fake<ItemDto>();
            A.CallTo(() => _mapper.Map<ItemDto>(item)).Returns(itemDto);

            //Act
            var result = itemRepository.GetItem(itemId);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<Task<ItemDto>>();
        }

        [Fact]
        public async void ItemRepository_GetItemsByCategory_ReturnsTaskWithListOfItemDto()
        {
            //Arrange
            string categoryUrl = "sssss";
            var dataContext = await GetDataContext();
            var itemRepository = new ItemRepository(dataContext, _mapper);
            var itemsByCategory = A.Fake<List<Item>>();
            var itemsByCategoryDto = A.Fake<List<ItemDto>>();
            A.CallTo(() => _mapper.Map<List<ItemDto>>(itemsByCategory)).Returns(itemsByCategoryDto);

            //Act
            var result = itemRepository.GetItemsByCategory(categoryUrl);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<Task<List<ItemDto>>>();
        }

        [Fact]
        public async void ItemRepository_SearchItem_ReturnsTaskWithListOfItemDto()
        {
            //Arrange
            string searchText = "sssss";
            var dataContext = await GetDataContext();
            var itemRepository = new ItemRepository(dataContext, _mapper);
            var searchItem = A.Fake<List<Item>>();
            var searchItemDto = A.Fake<List<ItemDto>>();
            A.CallTo(() => _mapper.Map<List<ItemDto>>(searchItem)).Returns(searchItemDto);

            //Act
            var result = itemRepository.SearchItem(searchText);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<Task<List<ItemDto>>>();
        }

        [Fact]
        public async void ItemRepository_GetItemSearchSuggestions_ReturnsTaskWithListOfString()
        {
            //Arrange
            string searchText = "sssss";
            var dataContext = await GetDataContext();
            var itemRepository = new ItemRepository(dataContext, _mapper);
            var items = A.Fake<List<ItemDto>>();
            A.CallTo(() => itemRepository.SearchItem(searchText)).Returns(items);

            //Act
            var result = itemRepository.GetItemSearchSuggestions(searchText);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<Task<List<string>>>();
        }

        [Fact]
        public async void CategoryRepository_GetAdminItems_ReturnsTaskWithListOfItemDtos()
        {
            //Arrange
            var dataContext = await GetDataContext();
            var itemRepository = new ItemRepository(dataContext, _mapper);
            var items = A.Fake<ICollection<Item>>();
            var itemsDto = A.Fake<List<ItemDto>>();
            A.CallTo(() => _mapper.Map<List<ItemDto>>(items)).Returns(itemsDto);

            //Act
            var result = itemRepository.GetAdminItems();

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<Task<List<ItemDto>>>();
        }

        [Fact]
        public async void ItemRepository_CreateItem_ReturnsTaskWithItemDto()
        {
            //Arrange
            var dataContext = await GetDataContext();
            var itemRepository = new ItemRepository(dataContext, _mapper);
            var item = A.Fake<Item>();
            var itemDto = A.Fake<ItemDto>();
            A.CallTo(() => _mapper.Map<ItemDto>(item)).Returns(itemDto);

            //Act
            var result = itemRepository.CreateItem(itemDto);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<Task<ItemDto>>();
        }

        [Fact]
        public async void ItemRepository_DeleteItem_ReturnsBoolean()
        {
            //Arrange
            var itemId = 1;
            var dataContext = await GetDataContext();
            var itemRepository = new ItemRepository(dataContext, _mapper);
            var item = A.Fake<Item>();
            var itemDto = A.Fake<ItemDto>();
            A.CallTo(() => _mapper.Map<ItemDto>(item)).Returns(itemDto);

            //Act
            var result = itemRepository.DeleteItem(itemId);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<Task<bool>>();
        }

        [Fact]
        public async void ItemRepository_UpdateItem_ReturnsTaskWithItemDto()
        {
            //Arrange
            var itemId = 1;
            var dataContext = await GetDataContext();
            var itemRepository = new ItemRepository(dataContext, _mapper);
            var item = A.Fake<Item>();
            var itemDto = A.Fake<ItemDto>();
            A.CallTo(() => _mapper.Map<ItemDto>(item)).Returns(itemDto);

            //Act
            var result = itemRepository.UpdateItem(itemId, itemDto);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<Task<ItemDto>>();
        }
    }
}