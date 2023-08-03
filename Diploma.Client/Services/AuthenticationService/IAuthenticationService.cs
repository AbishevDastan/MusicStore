using Diploma.Domain;
using Diploma.DTO.User;

namespace Diploma.Client.Services.AuthenticationService
{
    public interface IAuthenticationService
    {
        Task<ResponseFromServer<string>> Login(AuthenticateUserDto request);
        Task<bool> IsAuthenticated();
    }
}
