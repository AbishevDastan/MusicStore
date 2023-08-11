using Diploma.Client.Services.AuthenticationService;
using Diploma.DTO.Order;
using Diploma.DTO.Orders;
using Microsoft.AspNetCore.Components;
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

        public List<OrderOverview> Orders { get; set; }

        public async Task<OrderDetails> GetOrderDetails(int orderId)
        {
            return await _httpClient.GetFromJsonAsync<OrderDetails>($"api/order/{orderId}");
        }

        public async Task<List<OrderOverview>> GetOrdersForUser() => await _httpClient.GetFromJsonAsync<List<OrderOverview>>("api/order");

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
                var orderOverview = Orders.FirstOrDefault(o => o.Id == orderId);
                if (orderOverview != null)
                {
                    orderOverview.Status = OrderStatus.Approved;
                }
            }
            else
            {
                await Console.Out.WriteLineAsync("Something went wrong.");
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
