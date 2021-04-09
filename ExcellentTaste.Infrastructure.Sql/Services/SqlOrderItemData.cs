using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExcellentTaste.Domain;
using ExcellentTaste.Domain.Models;
using ExcellentTaste.Domain.Services;
using ExcellentTaste.Infrastructure.Sql.DbContexts;
using Microsoft.EntityFrameworkCore;

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
            var entry = db.Add(newOrderItem);
            entry.State = EntityState.Added;
            db.SaveChanges();
        }

        public void Delete(int orderItemToRemoveOrderId, int orderItemToRemoveItemId)
        {
            OrderItem toDelete = Get(orderItemToRemoveOrderId, orderItemToRemoveItemId);
            var entry = db.Remove(toDelete);
            entry.State = EntityState.Deleted;
            db.SaveChanges();
        }

        public void Edit(OrderItem editedOrderItem)
        {
            var entry = db.Attach(editedOrderItem);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }

        public IEnumerable<OrderItem> Get(int orderId)
        {
            return db.OrderItems.Where(o => o.OrderId == orderId);
        }

        public OrderItem Get(int orderId, int itemId)
        {
            return db.OrderItems.Find(new int[] { orderId, itemId });
            //return db.OrderItems.FirstOrDefault(o => o.OrderId == orderId && o.ItemId == itemId);
        }
    }
}
