using Diploma.BusinessLogic.Repositories.AuthenticationRepository;
using Diploma.Domain;
using Diploma.Domain.Entities;
using Diploma.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Diploma.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationRepository _authenticationRepository;

        public AuthenticationController(IAuthenticationRepository authenticationRepository)
        {
            _authenticationRepository = authenticationRepository;
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<ResponseFromServer<int>>> Register(CreateUserDTO request)
        {
            var response = await _authenticationRepository.Register(new User { Email = request.Email}, request.Password);
            if(response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<ResponseFromServer<string>>> Login(AuthenticateUserDTO request)
        {
            var response = await _authenticationRepository.Login(request.Email, request.Password);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}
