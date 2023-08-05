using Diploma.DTO.Order;
using Diploma.DTO.Orders;

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
        Task<OrderDetails> GetOrderDetailsForAdmin(int orderId);
        Task<bool> ApproveOrder(int orderId);
        Task<int> GetOrdersCount();
    }
}
