﻿using Diploma.Client.Services.AuthenticationService;
using Diploma.Client.Services.UserService;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace Diploma.Client.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;
        private readonly IUserService _userService;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly IAuthenticationService _authenticationService;

        public OrderService(HttpClient httpClient, NavigationManager navigationManager, IUserService userService, AuthenticationStateProvider authenticationStateProvider, IAuthenticationService authenticationService)
        {
            _httpClient = httpClient;
            _navigationManager = navigationManager;
            _userService = userService;
            _authenticationStateProvider = authenticationStateProvider;
            _authenticationService = authenticationService;
        }
        public async Task PlaceOrder()
        {
            if(await _authenticationService.IsAuthenticated())
            {
                await _httpClient.PostAsync("api/order", null);
            }
            else
            {
                _navigationManager.NavigateTo("login");
            }
        }
    }
}
