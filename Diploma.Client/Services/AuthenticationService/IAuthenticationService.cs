using Diploma.Domain;
using Diploma.DTO;

namespace Diploma.Client.Services.AuthenticationService
{
    public interface IAuthenticationService
    {
        Task<ResponseFromServer<string>> Login(AuthenticateUserDto request);
    }
}
