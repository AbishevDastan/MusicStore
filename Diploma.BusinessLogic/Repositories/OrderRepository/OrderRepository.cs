using Diploma.BusinessLogic.Repositories.CartRepository;
using Diploma.BusinessLogic.Repositories.UserRepository;
using Diploma.DataAccess;
using Diploma.Domain.Entities;

namespace Diploma.BusinessLogic.Repositories.OrderRepository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _dataContext;
        private readonly ICartRepository _cartRepository;
        private readonly IUserRepository _userRepository;

        public OrderRepository(DataContext dataContext, ICartRepository cartRepository, IUserRepository userRepository)
        {
            _dataContext = dataContext;
            _cartRepository = cartRepository;
            _userRepository = userRepository;
        }
        //public async Task<bool> PlaceOrder()
        //{
        //    decimal total = 0;
        //    var items = await _cartRepository.GetCartItemsFromDatabase();
        //    foreach (var item in items)
        //    {
        //        total += item.Price * item.Quantity;
        //    }

        //    var orderItems = new List<OrderItem>();
        //    foreach (var item in items)
        //    {
        //        orderItems.Add(new OrderItem
        //        {
        //            ItemId = item.ItemId,
        //            Quantity = item.Quantity,
        //            Total = item.Price * item.Quantity
        //        });
        //    }

        //    var order = new Order
        //    {
        //        UserId = _userRepository.GetUserId(),
        //        PlacedAt = DateTime.Now,
        //        Total = total,
        //        OrderItems = orderItems
        //    };

        //    _dataContext.Orders.Add(order);
        //    await _dataContext.SaveChangesAsync();

        //    return true;
        //}
    }
}
