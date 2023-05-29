using Diploma.Domain;
using Diploma.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.BusinessLogic.Repositories.AuthenticationRepository
{
    public interface IAuthenticationRepository
    {
        Task<ResponseFromServer<int>> Register(User user, string password);
        Task<bool> UserRegistered(string email);
        Task<ResponseFromServer<string>> Login(string email, string password);
        Task<ResponseFromServer<bool>> ChangePassword(int userid, string newPassword);
    }
}
