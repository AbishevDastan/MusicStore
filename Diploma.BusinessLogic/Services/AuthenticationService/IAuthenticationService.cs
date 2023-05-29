using Diploma.Domain;
using Diploma.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.BusinessLogic.Services.AuthenticationService
{
    public interface IAuthenticationService
    {
        Task<ResponseFromServer<int>> Register(CreateUserDTO request);
        Task<ResponseFromServer<string>> Login(AuthenticateUserDTO request);
    }
}
