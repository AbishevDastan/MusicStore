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
        private readonly IUserRepository _userRepository;
        private readonly IUserContext _userContext;

        public OrderRepository(DataContext dataContext, ICartRepository cartRepository, IUserRepository userRepository, IUserContext userContext)
        {
            _dataContext = dataContext;
            _cartRepository = cartRepository;
            _userRepository = userRepository;
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

            var order = new List<OrderOverview>();
            orders.ForEach(o => order.Add(new OrderOverview
            {
                Id = o.Id,
                OrderDate = o.OrderDate,
                TotalPrice = o.TotalPrice,
                Item = o.OrderItems.Any() ?
                    $"{o.OrderItems.First().Item.Name} and" +
                    $" {o.OrderItems.Count - 1} more..." :
                    o.OrderItems.First().Item.Name
            }));

            return order;
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
                OrderItems = orderItems
            };

            _dataContext.Orders.Add(order);
            await _dataContext.SaveChangesAsync();

            return true;
        }
    }
}
