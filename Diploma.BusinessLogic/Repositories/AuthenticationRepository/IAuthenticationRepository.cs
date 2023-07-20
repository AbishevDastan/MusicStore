using Diploma.Domain;

namespace Diploma.BusinessLogic.Repositories.AuthenticationRepository
{
    public interface IAuthenticationRepository
    {
        Task<ResponseFromServer<string>> Login(string email, string password);
    }
}
