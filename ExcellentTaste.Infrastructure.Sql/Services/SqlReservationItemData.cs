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
    public class SqlReservationItemData : IReservationItemData
    {
        private readonly ExcellentTasteContext db;

        public SqlReservationItemData(ExcellentTasteContext db)
        {
            this.db = db;
        }

        public void Create(ReservationItem newReservationItem)
        {
            var entry = db.Add(newReservationItem);
            entry.State = EntityState.Added;
            db.SaveChanges();
        }

        public void Delete(int reservationItemToRemoveReservationId, int reservationItemToRemoveItemId)
        {
            ReservationItem toDelete = Get(reservationItemToRemoveReservationId, reservationItemToRemoveItemId);
            var entry = db.Remove(toDelete);
            entry.State = EntityState.Deleted;
            db.SaveChanges();
        }

        public void Edit(ReservationItem editedReservationItem)
        {
            var entry = db.Attach(editedReservationItem);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }

        public IEnumerable<ReservationItem> Get(int reservationId)
        {
            return db.ReservationItems.Where(r => r.ReservationId == reservationId);
        }

        public ReservationItem Get(int orderId, int itemId)
        {
            return db.ReservationItems.Find(new int[] { orderId, itemId });
            //return db.OrderItems.FirstOrDefault(o => o.OrderId == orderId && o.ItemId == itemId);
        }
    }
}
