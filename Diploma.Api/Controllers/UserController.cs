﻿using Diploma.BusinessLogic.Repositories.UserRepository;
using Diploma.Domain;
using Diploma.Domain.Entities;
using Diploma.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Diploma.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        [Route("change-password")]
        [Authorize]
        public async Task<ActionResult<ResponseFromServer<bool>>> ChangePassword([FromBody] string newPassword)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var response = await _userRepository.ChangePassword(int.Parse(userId), newPassword);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<ResponseFromServer<int>>> Register(CreateUserDto request)
        {
            var response = await _userRepository.Register(new User { Email = request.Email }, request.Password);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}