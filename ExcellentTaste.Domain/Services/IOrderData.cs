using System;
using System.Collections.Generic;
using System.Text;

namespace ExcellentTaste.Domain.Services
{
    public interface IOrderData
    {
        IEnumerable<Order> GetAll();
        IEnumerable<Order> GetAllButOld();
        IEnumerable<Order> GetAllOnDay(int year, int month, int day);
        Order Get(int orderId);
        void Create(Order newOrder);
        void Edit(Order editedOrder);
    }
}
