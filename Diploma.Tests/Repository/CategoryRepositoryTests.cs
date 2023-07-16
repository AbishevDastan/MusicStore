using AutoMapper;
using Bogus;
using Diploma.BusinessLogic.Repositories.CategoryRepository;
using Diploma.DataAccess;
using Diploma.Domain.Entities;
using Diploma.DTO;
using FakeItEasy;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace Diploma.Tests.Repository
{
    public class CategoryRepositoryTests
    {
        private readonly IMapper _mapper;
        public CategoryRepositoryTests()
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
            if (await dataContext.Categories.CountAsync() <= 0)
            {
                for (int i = 0; i < 10; i++)
                {
                    dataContext.Categories.Add(
                        new Category()
                        {
                            Name = "Lalala",
                            Url = "lalala",
                            ImageUrl = "https://images.unsplash.com/photo-1605020420620-20c943cc4669?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTF8fGd1aXRhcnxlbnwwfHwwfHx8MA%3D%3D&w=1000&q=80"
                        });
                    await dataContext.SaveChangesAsync();
                }
            }
            return dataContext;
        }
        [Fact]
        public async void CategoryRepository_GetCategories_ReturnsTaskWithListOfCategoryDtos()
        {
            //Arrange
            var dataContext = await GetDataContext();
            var categoryRepository = new CategoryRepository(dataContext, _mapper);
            var categoriesDto = A.Fake<ICollection<CategoryDto>>();
            var categoriesDtoList = A.Fake<List<CategoryDto>>();
            A.CallTo(() => _mapper.Map<List<CategoryDto>>(categoriesDto)).Returns(categoriesDtoList);

            //Act
            var result = categoryRepository.GetCategories();

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<Task<List<CategoryDto>>>();
        }

        [Fact]
        public async void CategoryRepository_GetCategory_ReturnsTaskWithCategoryDto()
        {
            //Arrange
            int categoryId = 1;
            var dataContext = await GetDataContext();
            var categoryRepository = new CategoryRepository(dataContext, _mapper);
            var category = A.Fake<CategoryDto>();
            var categoryDto = A.Fake<CategoryDto>();
            A.CallTo(() => _mapper.Map<CategoryDto>(category)).Returns(categoryDto);

            //Act
            var result = categoryRepository.GetCategory(categoryId);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<Task<CategoryDto>>();
        }

        [Fact]
        public async void CategoryRepository_GetAdminCategories_ReturnsTaskWithListOfCategoryDtos()
        {
            //Arrange
            var dataContext = await GetDataContext();
            var categoryRepository = new CategoryRepository(dataContext, _mapper);
            var categoriesDto = A.Fake<ICollection<CategoryDto>>();
            var categoriesDtoList = A.Fake<List<CategoryDto>>();
            A.CallTo(() => _mapper.Map<List<CategoryDto>>(categoriesDto)).Returns(categoriesDtoList);

            //Act
            var result = categoryRepository.GetCategories();

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<Task<List<CategoryDto>>>();
        }

        //Bogus data generator
        //private List<CategoryDto> GenerateData(int count)
        //{
        //    var faker = new Faker<CategoryDto>()
        //        .RuleFor(i => i.Id, f => f.IndexFaker)
        //        .RuleFor(n => n.Name, f => f.Person.FirstName)
        //        .RuleFor(u => u.Url, f => f.Person.FirstName.ToLower())
        //        .RuleFor(iu => iu.ImageUrl, f => f.Person.FirstName);

        //    return faker.Generate(count);
        //}
    }
}
