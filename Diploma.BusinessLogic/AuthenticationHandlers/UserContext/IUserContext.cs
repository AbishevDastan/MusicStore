namespace Diploma.BusinessLogic.AuthenticationHandlers.UserContext
{
    public interface IUserContext
    {
        int GetUserId();
        bool IsAuthenticated();
    }
}
