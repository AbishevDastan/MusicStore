using Diploma.BusinessLogic.AuthenticationHandlers.HashManager;
using Diploma.BusinessLogic.AuthenticationHandlers.UserContext;
using Diploma.DataAccess;
using Diploma.Domain;
using Diploma.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Diploma.BusinessLogic.Repositories.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _dataContext;
        private readonly IHashManager _hashManager;
        private readonly IUserContext _userContext;

        public UserRepository(DataContext dataContext, IHashManager hashManager, IUserContext userContext)
        {
            _dataContext = dataContext;
            _hashManager = hashManager;
            _userContext = userContext;
        }
        public async Task<ResponseFromServer<bool>> ChangePassword(int userId, string newPassword)
        {
            var user = await _dataContext.Users.FindAsync(userId);
            if (user == null)
            {
                return new ResponseFromServer<bool>
                {
                    Success = false,
                    Message = "User not found."
                };
            }

            _hashManager.CreateHash(newPassword, out byte[] hash, out byte[] salt);
            user.Hash = hash;
            user.Salt = salt;

            await _dataContext.SaveChangesAsync();

            return new ResponseFromServer<bool>
            {
                Data = true,
                Message = "The password has been changed successfully."
            };
        }

        public async Task<ResponseFromServer<int>> Register(User user, string password)
        {
            if (await UserRegistered(user.Email))
            {
                return new ResponseFromServer<int>
                {
                    Success = false,
                    Message = "Sorry, this email address is already used. Please, try another one."
                };
            }

            _hashManager.CreateHash(password, out byte[] hash, out byte[] salt);
            user.Hash = hash;
            user.Salt = salt;

            _dataContext.Users.Add(user);
            await _dataContext.SaveChangesAsync();

            return new ResponseFromServer<int> { Data = user.Id, Message = "Success!" };

        }

        public async Task<bool> UserRegistered(string email)
        {
            if (await _dataContext.Users.AnyAsync(user => user.Email.ToLower()
            == email.ToLower()))
            {
                return true;
            }
            return false;
        }

        public async Task<User> GetUser(int userId)
        {
            return await _dataContext.Users.FindAsync(userId);
        }

        public async Task<User> GetCurrentUser()
        {
            return await _dataContext.Users.FindAsync(_userContext.GetUserId());
        }

        public async Task<User> GetCurrentUserWithId(int userId)
        {
            //userId = _userContext.GetUserId();
            return await _dataContext.Users.FindAsync(userId);
        }
    }
}
