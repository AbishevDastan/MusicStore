using Diploma.Domain.Entities;
using Diploma.DTO.Order;
using Diploma.DTO.Orders;

namespace Diploma.BusinessLogic.Repositories.OrderRepository
{
    public interface IOrderRepository
    {
        Task<Order?> GetOrder(int? orderId);
        Task<bool> IsDeliveryInfoLinkedToOrders(int deliveryInfoId);
        Task<OrderDetails> GetOrderDetails(int orderId);
        Task<List<OrderOverview>> GetOrdersForUser();
        Task<bool> PlaceOrder(int deliveryInfoId);
        Task<bool> CancelOrder(int orderId);

        //Admin Panel
        Task<List<OrderOverview>> GetAllOrders();
        Task<OrderDetails> GetOrderDetailsForAdmin(int orderId);
        Task ApproveOrder(int orderId);
        Task SetStatusToShipped(int orderId);
        Task SetStatusToDelivered(int orderId);
        Task<int> GetOrdersCount();
        Task<User> GetCurrentUser(int userId);
    }
}
