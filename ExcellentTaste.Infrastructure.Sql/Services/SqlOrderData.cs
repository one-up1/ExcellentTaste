using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExcellentTaste.Domain;
using ExcellentTaste.Domain.Services;
using ExcellentTaste.Infrastructure.Sql.DbContexts;

namespace ExcellentTaste.Infrastructure.Sql.Services
{
    class SqlOrderData : IOrderData
    {
        private readonly OrderDbContext db;

        public SqlOrderData(OrderDbContext db)
        {
            this.db = db;
        }

        public void Create(Order newOrder)
        {
            var entry = db.Entry(newOrder);
            entry.State = System.Data.Entity.EntityState.Added;
            db.SaveChanges();
        }

        public void Edit(Order editedOrder)
        {
            var entry = db.Entry(editedOrder);
            entry.State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public Order Get(int orderId)
        {
            return db.Orders.FirstOrDefault(o => o.Id == orderId);
        }

        public IEnumerable<Order> GetAll()
        {
            return db.Orders;
        }

        public IEnumerable<Order> GetAllButOld()
        {
            DateTime currentDatetime = DateTime.Now;
            return db.Orders.Where(o => o.StartTime.Year >= currentDatetime.Year && o.StartTime.Month >= currentDatetime.Month && o.StartTime.Day >= currentDatetime.Day);
        }

        public IEnumerable<Order> GetAllToday()
        {
            DateTime currentDatetime = DateTime.Now;
            return db.Orders.Where(o => o.StartTime.Year == currentDatetime.Year && o.StartTime.Month == currentDatetime.Month && o.StartTime.Day == currentDatetime.Day);
        }
    }
}
