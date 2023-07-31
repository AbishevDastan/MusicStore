using Diploma.Client.Services.AuthenticationService;
using Diploma.Client.Services.UserService;
using Diploma.Domain.Entities;
using Diploma.DTO;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

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

        public List<OrderOverview> Orders { get; set; }

        public async Task<OrderDetails> GetOrderDetails(int orderId)
        {
            return await _httpClient.GetFromJsonAsync<OrderDetails>($"api/order/{orderId}");
        }

        public async Task<List<OrderOverview>> GetOrdersForUser()
        {
            return await _httpClient.GetFromJsonAsync<List<OrderOverview>>("api/order");
        }

        public async Task<List<OrderOverview>> GetOrdersForAdmin()
        {
            return await _httpClient.GetFromJsonAsync<List<OrderOverview>>("api/order/admin");
        }

        public async Task ApproveOrder(int orderId)
        {
            var response = await _httpClient.PostAsync($"api/order/admin/{orderId}/approve", null);
            if (response.IsSuccessStatusCode)
            {
                var order = Orders.FirstOrDefault(o => o.Id == orderId);
                if (order != null)
                {
                    order.Status = OrderStatus.Approved;
                }
            }
            else
            {
                // Handle error (e.g., order not found)
                // Display error message to the user
            }
        }
        public async Task PlaceOrder()
        {
            if (await _authenticationService.IsAuthenticated())
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
