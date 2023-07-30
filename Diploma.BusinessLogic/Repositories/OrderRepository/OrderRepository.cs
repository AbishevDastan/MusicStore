using Diploma.BusinessLogic.AuthenticationHandlers.UserContext;
using Diploma.BusinessLogic.Repositories.CartRepository;
using Diploma.BusinessLogic.Repositories.UserRepository;
using Diploma.DataAccess;
using Diploma.Domain.Entities;
using Diploma.DTO;
using Microsoft.EntityFrameworkCore;

namespace Diploma.BusinessLogic.Repositories.OrderRepository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _dataContext;
        private readonly ICartRepository _cartRepository;
        private readonly IUserContext _userContext;

        public OrderRepository(DataContext dataContext, ICartRepository cartRepository, IUserContext userContext)
        {
            _dataContext = dataContext;
            _cartRepository = cartRepository;
            _userContext = userContext;
        }

        public async Task<List<OrderOverview>> GetUserOrders()
        {
            var orders = await _dataContext.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Item)
                .Where(o => o.UserId == _userContext.GetUserId())
                .OrderByDescending(o => o.OrderDate)
                .ToListAsync();

            var orderOverviewList = new List<OrderOverview>();
            foreach (var order in orders)
            {
                var orderOverview = new OrderOverview
                {
                    Id = order.Id,
                    OrderDate = order.OrderDate,
                    TotalPrice = order.TotalPrice,
                    Item = order.OrderItems.Any() ?
                    $"{order.OrderItems.First().Item.Name} and" +
                    $" {order.OrderItems.Count - 1} more..." :
                    order.OrderItems.First().Item.Name,
                    Status = order.Status
                };
                orderOverviewList.Add(orderOverview);
            }
            return orderOverviewList;
        }

        public async Task<bool> PlaceOrder()
        {
            decimal total = 0;
            var items = await _cartRepository.GetCartItemsFromDatabase();
            foreach (var item in items)
            {
                total += item.Price * item.Quantity;
            }

            var orderItems = new List<OrderItem>();
            foreach (var item in items)
            {
                orderItems.Add(new OrderItem
                {
                    ItemId = item.ItemId,
                    Quantity = item.Quantity,
                    TotalPrice = item.Price * item.Quantity
                });
            }

            var order = new Order
            {
                UserId = _userContext.GetUserId(),
                OrderDate = DateTime.Now,
                TotalPrice = total,
                OrderItems = orderItems,
                Status = OrderStatus.Pending
            };

            _dataContext.Orders.Add(order);
            await _dataContext.SaveChangesAsync();

            return true;
        }
    }
}
