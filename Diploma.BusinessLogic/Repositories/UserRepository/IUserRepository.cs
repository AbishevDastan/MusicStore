using Diploma.Domain;
using Diploma.Domain.Entities;

namespace Diploma.BusinessLogic.Repositories.UserRepository
{
    public interface IUserRepository
    {
        Task<ResponseFromServer<bool>> ChangePassword(int userid, string newPassword);
        Task<ResponseFromServer<int>> Register(User user, string password);
        Task<bool> UserRegistered(string email);

    }
}