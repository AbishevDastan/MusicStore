using Diploma.BusinessLogic.AuthenticationHandlers.HashManager;
using Diploma.BusinessLogic.AuthenticationHandlers.JwtManager;
using Diploma.DataAccess;
using Diploma.Domain;
using Microsoft.EntityFrameworkCore;

namespace Diploma.BusinessLogic.Repositories.AuthenticationRepository
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly DataContext _dataContext;
        private readonly IJwtManager _jwtManager;
        private readonly IHashManager _hashManager;

        public AuthenticationRepository(DataContext dataContext, IJwtManager jwtManager, IHashManager hashManager)
        {
            _dataContext = dataContext;
            _jwtManager = jwtManager;
            _hashManager = hashManager;
        }

        public async Task<ResponseFromServer<string>> Login(string email, string password)
        {
            var response = new ResponseFromServer<string>();
            var user = await _dataContext.Users.FirstOrDefaultAsync(user => user.Email.ToLower() 
            == email.ToLower());

            if (user == null) 
            { 
                response.Success = false; 
                response.Message = "Sorry, the user with this email address is not found."; 
            }
            else if (!(_hashManager.VerifyHash(password, user.Hash, user.Salt)))
            {
                response.Success = false;
                response.Message = "The password is incorrect. Please, try again.";
            }
            else
            {
                response.Data = _jwtManager.GenerateJwtToken(user);
            }

            return response;
        }
    }
}
