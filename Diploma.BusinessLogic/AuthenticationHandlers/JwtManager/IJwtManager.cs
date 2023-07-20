using Diploma.Domain.Entities;

namespace Diploma.BusinessLogic.AuthenticationHandlers.JwtManager
{
    public interface IJwtManager
    {
        string GenerateJwtToken(User user);
    }
}
