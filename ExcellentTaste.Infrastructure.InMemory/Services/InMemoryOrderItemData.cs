using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExcellentTaste.Domain;
using ExcellentTaste.Domain.Services;

namespace ExcellentTaste.Infrastructure.InMemory.Services
{
    public class InMemoryOrderItemData : IOrderItemData
    {
        private List<OrderItem> orderItems;

        public InMemoryOrderItemData()
        {
            orderItems = new List<OrderItem>()
            {
                new OrderItem() { OrderId = 1, ItemId = 1, Amount = 1, Price = 5.50F, Prepared = false, Delivered = false },
                new OrderItem() { OrderId = 1, ItemId = 2, Amount = 1, Price = 1.50F, Prepared = true, Delivered = false },
                new OrderItem() { OrderId = 2, ItemId = 1, Amount = 2, Price = 5.50F, Prepared = true, Delivered = true }
            };
        }

        public void Create(OrderItem newOrderItem)
        {
            orderItems.Add(newOrderItem);
        }

        public void Delete(OrderItem orderItemToRemove)
        {
            orderItems.Remove(orderItemToRemove);
        }

        public void Edit(OrderItem editedOrderItem)
        {
            for(int i = 0; i < orderItems.Count; i++)
            {
                if(orderItems[i].OrderId == editedOrderItem.OrderId && orderItems[i].ItemId == editedOrderItem.ItemId)
                {
                    orderItems[i] = editedOrderItem;
                    return;
                }
            }
        }

        public IEnumerable<OrderItem> Get(int orderId)
        {
            return orderItems.Where(o => o.OrderId == orderId);
        }

        public OrderItem Get(int orderId, int itemId)
        {
            return orderItems.FirstOrDefault(o => o.OrderId == orderId && o.ItemId == itemId);
        }
    }
}
