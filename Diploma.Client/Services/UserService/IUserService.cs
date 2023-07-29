using Diploma.Domain;
using Diploma.DTO;

namespace Diploma.Client.Services.UserService
{
    public interface IUserService
    {
        Task<ResponseFromServer<int>> Register(CreateUserDto request);
        Task<ResponseFromServer<bool>> ChangePassword(ChangePasswordDto request);
        //Task<bool> IsAuthenticated();
    }
}
