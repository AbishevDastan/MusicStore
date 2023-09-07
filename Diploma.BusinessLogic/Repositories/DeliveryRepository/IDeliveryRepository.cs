using Diploma.Domain.Entities;

namespace Diploma.BusinessLogic.Repositories.DeliveryRepository
{
    public interface IDeliveryRepository
    {
        Task<List<DeliveryInformation>> GetDeliveryInfos();
        Task<DeliveryInformation> GetDeliveryInfo(int id);
        Task<DeliveryInformation> GetDeliveryInfoForAdmin(int id);
        Task<bool> AddOrUpdateDeliveryInfo(DeliveryInformation deliveryInfo);
        Task<bool> DeleteDeliveryInfo(int deliveryInfoId);
        Task<int> GetDeliveryInfosCount();
    }
}
