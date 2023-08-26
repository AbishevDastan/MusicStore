using Diploma.Domain.Entities;

namespace Diploma.Client.Services.DeliveryService
{
    public interface IDeliveryService
    {
        Task<DeliveryInformation> GetDeliveryInfo(int id);
        Task AddOrUpdateDeliveryInfo(DeliveryInformation deliveryInfo);
    }
}
