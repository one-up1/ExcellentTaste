using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExcellentTaste.Domain.Models;
using ExcellentTaste.Domain.Services;
using ExcellentTaste.Infrastructure.Sql.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace ExcellentTaste.Infrastructure.Sql.Services
{
    public class SqlOrderData : IOrderData
    {
        private readonly OrderDbContext db;

        public SqlOrderData(OrderDbContext db)
        {
            this.db = db;
        }

        public void Create(Order newOrder)
        {
            var entry = db.Add(newOrder);
            entry.State = EntityState.Added;
            db.SaveChanges();
        }

        public void Edit(Order editedOrder)
        {
            var entry = db.Attach(editedOrder);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }

        public Order Get(int orderId)
        {
            return db.Orders.Find(orderId);
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

        public IEnumerable<Order> GetAllOnDay(int year, int month, int day)
        {
            return db.Orders.Where(o => o.StartTime.Year == year && o.StartTime.Month == month && o.StartTime.Day == day);
        }
    }
}
