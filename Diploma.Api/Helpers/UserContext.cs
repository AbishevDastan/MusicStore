using Diploma.BusinessLogic.AuthenticationHandlers.UserContext;
using System.Security.Principal;

namespace Diploma.Api.Helpers
{
    public class UserContext : IUserContext
    {
        private readonly IHttpContextAccessor _accessor;

        public UserContext(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        private IIdentity? UserIdentity => _accessor.HttpContext?.User.Identity;

        public int GetUserId()
        {
            var nameClaim = UserIdentity?.Name;
            if (!string.IsNullOrEmpty(nameClaim) && int.TryParse(nameClaim, out var userId))
            {
                return userId;
            }

            throw new ApplicationException("Error occured. User must be authenticated.");
        }

        public bool IsAuthenticated()
        {
            return UserIdentity!.IsAuthenticated;
        }
    }
}
