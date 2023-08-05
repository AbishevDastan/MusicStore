using Diploma.Client.Services.AuthenticationService;
using Diploma.Client.Services.CartService;
using Diploma.Client.Services.UserService;
using Diploma.Client.Shared;
using Diploma.Domain.Entities;
using Diploma.DTO.Order;
using Diploma.DTO.Orders;
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

        private readonly IAuthenticationService _authenticationService;

        public OrderService(HttpClient httpClient, NavigationManager navigationManager, IAuthenticationService authenticationService)
        {
            _httpClient = httpClient;
            _navigationManager = navigationManager;
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

        public async Task<OrderDetails> GetOrderDetailsForAdmin(int orderId)
        {
            return await _httpClient.GetFromJsonAsync<OrderDetails>($"api/order/admin/{orderId}");
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
        public async Task<int> GetOrdersCount()
        {
            return await _httpClient.GetFromJsonAsync<int>("api/order/admin/count");
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

        public async Task CancelOrder(int orderId)
        {
            if (await _authenticationService.IsAuthenticated())
            {
                await _httpClient.PutAsync($"api/order/{orderId}", null);
            }
            else
            {
                _navigationManager.NavigateTo("login");
            }
        }
    }
}
