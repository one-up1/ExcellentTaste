using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExcellentTaste.Domain;
using ExcellentTaste.Domain.Services;
using ExcellentTaste.Infrastructure.Sql.DbContexts;

namespace ExcellentTaste.Infrastructure.Sql.Services
{
    public class SqlOrderItemData : IOrderItemData
    {
        private readonly OrderItemDbContext db;

        public SqlOrderItemData(OrderItemDbContext db)
        {
            this.db = db;
        }

        public void Create(OrderItem newOrderItem)
        {
            //db.OrderItems.Add(newOrderItem);
            var entry = db.Entry(newOrderItem);
            entry.State = System.Data.Entity.EntityState.Added;
            db.SaveChanges();
        }

        public void Delete(OrderItem orderItemToRemove)
        {
            //db.OrderItems.Remove(orderItemToRemove);
            var entry = db.Entry(orderItemToRemove);
            entry.State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
        }

        public void Edit(OrderItem editedOrderItem)
        {
            var entry = db.Entry(editedOrderItem);
            entry.State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public IEnumerable<OrderItem> Get(int orderId)
        {
            return db.OrderItems.Where(o => o.OrderId == orderId);
        }

        public OrderItem Get(int orderId, int itemId)
        {
            return db.OrderItems.FirstOrDefault(o => o.OrderId == orderId && o.ItemId == itemId);
        }
    }
}
