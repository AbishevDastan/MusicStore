using Diploma.Domain.Entities;

namespace Diploma.Client.Services.DeliveryService
{
    public interface IDeliveryService
    {
        Task<List<DeliveryInformation>> GetDeliveryInfos();
        Task<DeliveryInformation> GetDeliveryInfo(int id);
        Task<DeliveryInformation> GetDeliveryInfoForAdmin(int id);
        Task AddOrUpdateDeliveryInfo(DeliveryInformation deliveryInfo);
        Task DeleteDeliveryInfo(int id);
        Task LinkDeliveryInfoToOrder(int deliveryInfoId, int orderId);
        Task<int> GetDeliveryInfosCount();
    }
}
