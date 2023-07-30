using Diploma.DTO;

namespace Diploma.Client.Services.OrderService
{
    public interface IOrderService
    {
        Task PlaceOrder();

        //Admin Panel
        Task<List<OrderOverview>> GetOrdersForAdmin();

    }
}
