//using Diploma.DataAccess;
//using Diploma.Domain.Entities;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Diploma.Tests.Repository
//{
//    public class UserRepositoryTests
//    {
//         public async Task<DataContext> GetDataContext()
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
//                            Email = "lalala",
//                            Password = "https://images.unsplash.com/photo-1605020420620-20c943cc4669?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTF8fGd1aXRhcnxlbnwwfHwwfHx8MA%3D%3D&w=1000&q=80"
//                        });
//                    await dataContext.SaveChangesAsync();
//                }
//            }
//            return dataContext;
//        }
//    }
//}
