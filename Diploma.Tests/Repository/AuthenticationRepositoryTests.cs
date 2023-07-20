//using Diploma.BusinessLogic.AuthenticationHandlers.HashManager;
//using Diploma.BusinessLogic.AuthenticationHandlers.JwtManager;
//using Diploma.DataAccess;
//using Diploma.Domain.Entities;
//using FakeItEasy;
//using Microsoft.EntityFrameworkCore;

//namespace Diploma.Tests.Repository
//{
//    public class AuthenticationRepositoryTests
//    {
//        private readonly IHashManager _hashManager;
//        private readonly IJwtManager _jwtManager;
//        public AuthenticationRepositoryTests(IHashManager hashManager, IJwtManager jwtManager)
//        {
//            _hashManager = A.Fake<IHashManager>();
//            _jwtManager = A.Fake<IJwtManager>();
//        }

//        public async Task<DataContext> GetDataContext()
//        {
//            var options = new DbContextOptionsBuilder<DataContext>()
//                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
//                .Options;
//            var dataContext = new DataContext(options);
//            dataContext.Database.EnsureCreated();
//            if (await dataContext.Users.CountAsync() <= 0)
//            {
//                for (int i = 0; i < 10; i++)
//                {
//                    dataContext.Users.Add(
//                        new User()
//                        {
//                            Name = "Lalala",
//                            Url = "lalala",
//                            ImageUrl = "https://images.unsplash.com/photo-1605020420620-20c943cc4669?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTF8fGd1aXRhcnxlbnwwfHwwfHx8MA%3D%3D&w=1000&q=80"
//                        });
//                    await dataContext.SaveChangesAsync();
//                }
//            }
//            return dataContext;
//        }
//    }
//}
