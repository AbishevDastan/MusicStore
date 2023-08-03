using Diploma.DTO.Order;

namespace Diploma.Client.Services.OrderService
{
    public interface IOrderService
    {
        List<OrderOverview> Orders { get; set; }

        Task<List<OrderOverview>> GetOrdersForUser();
        Task<OrderDetails> GetOrderDetails(int orderId);
        Task PlaceOrder();
        Task CancelOrder(int orderId);

        //Admin Panel
        Task<List<OrderOverview>> GetOrdersForAdmin();
        Task<OrderDetails> GetOrderDetailsForAdmin(int orderId);
        Task ApproveOrder(int orderId);
        Task<int> GetOrdersCount();
    }
}
