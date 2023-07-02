using Diploma.Domain;
using Diploma.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.Client.Services.AuthenticationService
{
    public interface IAuthenticationService
    {
        Task<ResponseFromServer<int>> Register(CreateUserDto request);
        Task<ResponseFromServer<string>> Login(AuthenticateUserDto request);
        Task<ResponseFromServer<bool>> ChangePassword(ChangePasswordDto request);
    }
}
