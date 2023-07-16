using Diploma.Domain;
using Diploma.DTO;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.Client.Services.AuthenticationService
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authStateProvider;

        public AuthenticationService(HttpClient httpClient, AuthenticationStateProvider authStateProvider)
        {
            _httpClient = httpClient;
            _authStateProvider = authStateProvider;
        }

        public async Task<ResponseFromServer<int>> Register(CreateUserDto request)
        {
            var result = await _httpClient.PostAsJsonAsync("api/authentication/register", request);
            return await result.Content.ReadFromJsonAsync<ResponseFromServer<int>>();
        }

        public async Task<ResponseFromServer<string>> Login(AuthenticateUserDto request)
        {
            var result = await _httpClient.PostAsJsonAsync("api/authentication/login", request);
            return await result.Content.ReadFromJsonAsync<ResponseFromServer<string>>();
        }

        public async Task<ResponseFromServer<bool>> ChangePassword(ChangePasswordDto request)
        {
            var result = await _httpClient.PostAsJsonAsync("api/authentication/change-password", request.Password);
            return await result.Content.ReadFromJsonAsync<ResponseFromServer<bool>>();
        }

        public async Task<bool> IsAuthenticated()
        {
            return (await _authStateProvider.GetAuthenticationStateAsync()).User.Identity.IsAuthenticated;
        }
    }
}
