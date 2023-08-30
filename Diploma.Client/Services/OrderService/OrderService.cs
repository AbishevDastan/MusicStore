using Diploma.Client.Services.AuthenticationService;
using Diploma.Domain.Entities;
using Diploma.DTO.Order;
using Diploma.DTO.Orders;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;

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

        public event Action OrdersChanged;
        public List<OrderOverview> Orders { get; set; }


        public async Task<Order?> GetOrder(int? id) => await _httpClient.GetFromJsonAsync<Order>($"api/order/{id}");

        public async Task<OrderDetails> GetOrderDetails(int orderId) => await _httpClient.GetFromJsonAsync<OrderDetails>($"api/order/{orderId}/details");

        public async Task<List<OrderOverview>> GetOrdersForUser() => await _httpClient.GetFromJsonAsync<List<OrderOverview>>("api/order");

        public async Task<List<OrderOverview>> GetOrdersForAdmin() => await _httpClient.GetFromJsonAsync<List<OrderOverview>>("api/order/admin");

        public async Task<OrderDetails> GetOrderDetailsForAdmin(int orderId) => await _httpClient.GetFromJsonAsync<OrderDetails>($"api/order/admin/{orderId}/details");

        public async Task ApproveOrder(int orderId) => await _httpClient.PostAsync($"api/order/admin/{orderId}/approve", null);
        public async Task<int> GetOrdersCount() => await _httpClient.GetFromJsonAsync<int>("api/order/admin/count");

        public async Task PlaceOrder(int deliveryInfoId)
        {
            if (await _authenticationService.IsAuthenticated())
            {
                 await _httpClient.PostAsync($"api/order/{deliveryInfoId}", null);
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
