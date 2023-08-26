using Diploma.Domain.Entities;

namespace Diploma.BusinessLogic.Repositories.DeliveryRepository
{
    public interface IDeliveryRepository
    {
        Task<DeliveryInformation> GetDeliveryInfo(int id);
        Task<bool> AddOrUpdateDeliveryInfo(DeliveryInformation deliveryInfo);
    }
}
