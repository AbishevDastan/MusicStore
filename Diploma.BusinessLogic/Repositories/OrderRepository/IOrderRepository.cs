using Diploma.DTO;

namespace Diploma.BusinessLogic.Repositories.OrderRepository
{
    public interface IOrderRepository
    {
        Task<OrderDetails> GetOrderDetails(int orderId);
        Task<List<OrderOverview>> GetOrdersForUser();
        Task<bool> PlaceOrder();
        Task<bool> CancelOrder(int orderId);

        //Admin Panel
        Task<List<OrderOverview>> GetAllOrders();
        Task<bool> ApproveOrder(int orderId);

    }
}
