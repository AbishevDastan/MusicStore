using AutoMapper;
using Diploma.BusinessLogic.AuthenticationHandlers.UserContext;
using Diploma.BusinessLogic.Repositories.AuthenticationRepository;
using Diploma.BusinessLogic.Repositories.UserRepository;
using Diploma.Domain;
using Diploma.Domain.Entities;
using Diploma.DTO.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Diploma.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationRepository _authenticationRepository;
        private readonly IUserContext _userContext;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public AuthenticationController(IAuthenticationRepository authenticationRepository, IUserContext userContext, IUserRepository userRepository, IMapper mapper)
        {
            _authenticationRepository = authenticationRepository;
            _userContext = userContext;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<ResponseFromServer<string>>> Login(AuthenticateUserDto request)
        {
            var response = await _authenticationRepository.Login(request.Email, request.Password);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet]
        [Route("is-authenticated")]
        public async Task<bool> IsAuthenticated()
        {
            return _userContext.IsAuthenticated() ? true : false;
        }

        [HttpGet]
        [Route("authenticated-user")]
        [Authorize]
        public async Task<ActionResult<User>> AuthenticatedUser()
        {
            var user = await _userRepository.GetUser(_userContext.GetUserId());
            var userDto = _mapper.Map<UserDto>(user);
            return Ok(userDto);
        }
    }
}
