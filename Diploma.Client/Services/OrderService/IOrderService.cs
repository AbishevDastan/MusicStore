using Diploma.Domain.Entities;
using Diploma.DTO.Order;
using Diploma.DTO.Orders;

namespace Diploma.Client.Services.OrderService
{
    public interface IOrderService
    {
        List<OrderOverview> Orders { get; set; }

        Task<Order?> GetOrder(int? id);
        Task<bool> IsDeliveryInfoLinkedToOrders(int deliveryInfoId);
        Task<List<OrderOverview>> GetOrdersForUser();
        Task<OrderDetails> GetOrderDetails(int orderId);
        Task PlaceOrder(int deliveryInfoId);
        Task CancelOrder(int orderId);

        //Admin Panel
        Task<List<OrderOverview>> GetOrdersForAdmin();
        Task<OrderDetails> GetOrderDetailsForAdmin(int orderId);
        Task ApproveOrder(int orderId);
        Task<int> GetOrdersCount();
    }
}
