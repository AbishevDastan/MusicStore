﻿using Diploma.Domain;
using Diploma.DTO;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Json;

namespace Diploma.Client.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authStateProvider;

        public UserService(HttpClient httpClient, AuthenticationStateProvider authStateProvider)
        {
            _httpClient = httpClient;
            _authStateProvider = authStateProvider;
        }
        public async Task<ResponseFromServer<int>> Register(CreateUserDto request)
        {
            var result = await _httpClient.PostAsJsonAsync("api/user/register", request);
            return await result.Content.ReadFromJsonAsync<ResponseFromServer<int>>();
        }

        public async Task<ResponseFromServer<bool>> ChangePassword(ChangePasswordDto request)
        {
            var result = await _httpClient.PostAsJsonAsync("api/user/change-password", request.Password);
            return await result.Content.ReadFromJsonAsync<ResponseFromServer<bool>>();
        }

        public async Task<bool> IsAuthenticated()
        {
            return (await _authStateProvider.GetAuthenticationStateAsync()).User.Identity.IsAuthenticated;
        }
    }
}