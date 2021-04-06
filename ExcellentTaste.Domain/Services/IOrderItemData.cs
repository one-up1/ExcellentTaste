using System;
using System.Collections.Generic;
using System.Text;

namespace ExcellentTaste.Domain.Services
{
    public interface IOrderItemData
    {
        IEnumerable<OrderItem> Get(int orderId);
        OrderItem Get(int orderId, int itemId);
        void Edit(Order editedOrderItem);
        void Create(Order newOrderItem);
        void Delete(Order orderItemToRemove);
    }
}
