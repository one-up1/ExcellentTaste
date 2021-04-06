using System;
using System.Collections.Generic;
using System.Text;

namespace ExcellentTaste.Domain.Services
{
    interface IOrderData
    {
        IEnumerable<Order> GetAll();
        Order Get(int orderId);
        void Create(Order newOrder);
        void Edit(Order editedOrder);
    }
}
