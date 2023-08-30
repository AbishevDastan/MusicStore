using Diploma.Domain.Entities;
using Diploma.DTO.DeliveryInfo;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace Diploma.Client.Services.DeliveryService
{
    public class DeliveryService : IDeliveryService
    {
        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;

        public DeliveryService(HttpClient httpClient, NavigationManager navigationManager)
        {
            _httpClient = httpClient;
            _navigationManager = navigationManager;
        }

        public async Task<List<DeliveryInformation>> GetDeliveryInfos() => await _httpClient.GetFromJsonAsync<List<DeliveryInformation>>("api/delivery");

        public async Task<DeliveryInformation> GetDeliveryInfo(int id) => await _httpClient.GetFromJsonAsync<DeliveryInformation>($"api/delivery/{id}");
        public async Task<DeliveryInformation> GetDeliveryInfoForAdmin(int id) => await _httpClient.GetFromJsonAsync<DeliveryInformation>($"api/delivery/admin/{id}");

        public async Task AddOrUpdateDeliveryInfo(DeliveryInformation deliveryInfo)
        {
            await _httpClient.PostAsJsonAsync("api/delivery", deliveryInfo);
            _navigationManager.NavigateTo("/profile");
        }

        public async Task DeleteDeliveryInfo(int id)
        {
            await _httpClient.DeleteAsync($"api/delivery/{id}");
            _navigationManager.NavigateTo("/profile");
        }

        public async Task LinkDeliveryInfoToOrder(int deliveryInfoId, int orderId)
        {
            var dto = new LinkDeliveryInfoToOrderDto
            {
                OrderId = orderId,
                DeliveryInfoId = deliveryInfoId
            }; 

            await _httpClient.PostAsJsonAsync($"api/delivery/link-to-order", dto);
        }

        public async Task<int> GetDeliveryInfosCount() => await _httpClient.GetFromJsonAsync<int>("api/delivery/count");
    }
}