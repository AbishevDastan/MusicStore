using Diploma.DTO;

namespace Diploma.BusinessLogic.Repositories.OrderRepository
{
    public interface IOrderRepository
    {
        Task<List<OrderOverview>> GetUserOrders();
        Task<bool> PlaceOrder();
    }
}
