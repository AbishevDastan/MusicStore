using Diploma.DTO;

namespace Diploma.BusinessLogic.Repositories.OrderRepository
{
    public interface IOrderRepository
    {
        Task<OrderDetails> GetOrderDetails(int orderId);
        Task<List<OrderOverview>> GetOrdersForUser();
        Task<bool> PlaceOrder();

        //Admin Panel
        Task<List<OrderOverview>> GetAllOrders();
        Task<bool> ApproveOrder(int orderId);

    }
}
