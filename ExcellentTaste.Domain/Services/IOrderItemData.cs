using System;
using System.Collections.Generic;
using System.Text;
using ExcellentTaste.Domain.Models;

namespace ExcellentTaste.Domain.Services
{
    public interface IOrderItemData
    {
        IEnumerable<OrderItem> Get(int orderId);
        OrderItem Get(int orderId, int itemId);
        void Edit(OrderItem editedOrderItem);
        void Create(OrderItem newOrderItem);
        void Delete(int orderItemToRemoveOrderId, int orderItemToRemoveItemId);
    }
}
