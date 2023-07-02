using Diploma.DataAccess;
using Diploma.Domain;
using Diploma.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.BusinessLogic.Repositories.AuthenticationRepository
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly DataContext _dataContext;
        private readonly IConfiguration _configuration;

        public AuthenticationRepository(DataContext dataContext, IConfiguration configuration)
        {
            _dataContext = dataContext;
            _configuration = configuration;
        }

        public async Task<ResponseFromServer<int>> Register(User user, string password)
        {
            if (await UserRegistered(user.Email))
            {
                return new ResponseFromServer<int>
                {
                    Success = false,
                    Message = "Sorry, this email address is already used. Please, try another one."
                };
            }

            CreateHash(password, out byte[] hash, out byte[] salt);
            user.Hash = hash;
            user.Salt = salt;

            _dataContext.Users.Add(user);
            await _dataContext.SaveChangesAsync();

            return new ResponseFromServer<int> { Data = user.Id, Message = "Success!" };

        }

        private void CreateHash(string password, out byte[] hash, out byte[] salt) 
        {
            using(var hmac = new HMACSHA512())
            {
                salt = hmac.Key;
                hash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyHash(string password, byte[] hash, byte[] salt)
        {
            using(var hmac = new HMACSHA512(salt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(hash);
            }
        }

        private string GenerateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
               new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
               new Claim(ClaimTypes.Name, user.Email),
               new Claim(ClaimTypes.Role, user.Role)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("ApplicationSettings:Secret").Value));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken
                (
                    claims: claims,
                    expires: DateTime.Now.AddHours(12),
                    signingCredentials: credentials
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }

        public async Task<bool> UserRegistered(string email)
        {
            if(await _dataContext.Users.AnyAsync(user => user.Email.ToLower()
            == email.ToLower()))
            {
                return true;
            }
                return false;
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
            else if (!VerifyHash(password, user.Hash, user.Salt))
            {
                response.Success = false;
                response.Message = "The password is incorrect. Please, try again.";
            }
            else
            {
                response.Data = GenerateToken(user);
            }

            return response;
        }

        public async Task<ResponseFromServer<bool>> ChangePassword(int userId, string newPassword)
        {
            var user = await _dataContext.Users.FindAsync(userId);
            if (user == null)
            {
                return new ResponseFromServer<bool>
                {
                    Success = false,
                    Message = "User not found."
                };
            }

            CreateHash(newPassword, out byte[] hash, out byte[] salt);
            user.Hash = hash;
            user.Salt = salt;

            await _dataContext.SaveChangesAsync();

            return new ResponseFromServer<bool> 
            { 
                Data = true, 
                Message = "The password has been changed successfully."
            };
        }
    }
}
