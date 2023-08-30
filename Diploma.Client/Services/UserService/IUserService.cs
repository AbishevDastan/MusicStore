using Diploma.Domain;
using Diploma.Domain.Entities;
using Diploma.DTO.User;

namespace Diploma.Client.Services.UserService
{
    public interface IUserService
    {
        Task<ResponseFromServer<int>> Register(CreateUserDto request);
        Task<ResponseFromServer<bool>> ChangePassword(ChangePasswordDto request);
        Task<User> GetCurrentUser();
    }
}
