using Diploma.Domain.Entities;
using System.Net.Http.Json;

namespace Diploma.Client.Services.DeliveryService
{
    public class DeliveryService : IDeliveryService
    {
        private readonly HttpClient _httpClient;

        public DeliveryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<DeliveryInformation> GetDeliveryInfo(int id)
        {
            return await _httpClient.GetFromJsonAsync<DeliveryInformation>($"api/delivery/{id}");
        }

        public async Task AddOrUpdateDeliveryInfo(DeliveryInformation deliveryInfo)
        {
            await _httpClient.PostAsJsonAsync("api/delivery", deliveryInfo);
        }
    }
}