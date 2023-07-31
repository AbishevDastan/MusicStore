using Diploma.DTO;

namespace Diploma.Client.Services.OrderService
{
    public interface IOrderService
    {
        List<OrderOverview> Orders { get; set; }

        Task<List<OrderOverview>> GetOrdersForUser();
        Task<OrderDetails> GetOrderDetails(int orderId);
        Task PlaceOrder();

        //Admin Panel
        Task<List<OrderOverview>> GetOrdersForAdmin();
        Task ApproveOrder(int orderId);

    }
}
