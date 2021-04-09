using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExcellentTaste.Domain.Models;
using ExcellentTaste.Domain.Services;

namespace ExcellentTaste.Infrastructure.InMemory.Services
{
    public class InMemoryOrderData : IOrderData
    {
        private readonly List<Order> orders;

        public InMemoryOrderData()
        {
            orders = new List<Order>()
            {
                new Order(){ Id = 1, StartTime = new DateTime(2021, 6, 10, 18, 30, 0), TableId = 1, FillingId = 1, WaitorId = 1, Completed = false},
                new Order(){ Id = 2, StartTime = new DateTime(2021, 6, 10, 13, 00, 0), TableId = 2, FillingId = 2, WaitorId = 2, Completed = true}
            };
        }

        public void Create(Order newOrder)
        {
            orders.Add(newOrder);
        }

        public void Edit(Order editedOrder)
        {
            for (int i = 0; i < orders.Count; i++)
            {
                if (orders[i].Id == editedOrder.Id)
                {
                    orders[i] = editedOrder;
                    return;
                }
            }
        }

        public Order Get(int orderId)
        {
            return orders.FirstOrDefault(o => o.Id == orderId);
        }

        public IEnumerable<Order> GetAll()
        {
            return orders;
        }

        public IEnumerable<Order> GetAllButOld()
        {
            DateTime currentDatetime = DateTime.Now;
            return orders.Where(o => o.StartTime.Year >= currentDatetime.Year && o.StartTime.Month >= currentDatetime.Month && o.StartTime.Day >= currentDatetime.Day);
        }

        public IEnumerable<Order> GetAllOnDay(int year, int month, int day)
        {
            return orders.Where(o => o.StartTime.Year == year && o.StartTime.Month == month && o.StartTime.Day == day);
        }
    }
}
