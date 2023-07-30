using Diploma.DTO;

namespace Diploma.BusinessLogic.Repositories.OrderRepository
{
    public interface IOrderRepository
    {
        Task<List<OrderOverview>> GetOrdersForUser();
        Task<List<OrderOverview>> GetAllOrders();
        Task<bool> PlaceOrder();
    }
}
