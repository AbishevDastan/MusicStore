﻿using Diploma.DTO.Orders;

namespace Diploma.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int DeliveryInformationId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus Status { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
