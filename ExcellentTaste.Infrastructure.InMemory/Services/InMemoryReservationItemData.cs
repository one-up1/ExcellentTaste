using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExcellentTaste.Domain.Models;
using ExcellentTaste.Domain.Services;

namespace ExcellentTaste.Infrastructure.InMemory.Services
{
    public class InMemoryReservationItemData : IReservationItemData
    {
        private readonly List<ReservationItem> ReservationItems;

        public InMemoryReservationItemData()
        {
            ReservationItems = new List<ReservationItem>()
            {
                new ReservationItem() { ReservationId = 1, ItemId = 1, Amount = 1, Price = 5.50F, Prepared = false, Delivered = false },
                new ReservationItem() { ReservationId = 1, ItemId = 2, Amount = 1, Price = 1.50F, Prepared = true, Delivered = false },
                new ReservationItem() { ReservationId = 2, ItemId = 1, Amount = 2, Price = 5.50F, Prepared = true, Delivered = true }
            };
        }

        public void Create(ReservationItem newReservationItem)
        {
            ReservationItems.Add(newReservationItem);
        }

        public void Delete(int reservationItemToRemoveReservationId, int reservationItemToRemoveItemId)
        {
            ReservationItem toDelete = Get(reservationItemToRemoveReservationId, reservationItemToRemoveItemId);
            if(toDelete != null)
            {
                ReservationItems.Remove(toDelete);
            }
        }

        public void Edit(ReservationItem editedReservationItem)
        {
            for(int i = 0; i < ReservationItems.Count; i++)
            {
                if(ReservationItems[i].ReservationId == editedReservationItem.ReservationId && ReservationItems[i].ItemId == editedReservationItem.ItemId)
                {
                    ReservationItems[i] = editedReservationItem;
                    return;
                }
            }
        }

        public IEnumerable<ReservationItem> Get(int reservationId)
        {
            return ReservationItems.Where(r => r.ReservationId == reservationId);
        }

        public ReservationItem Get(int reservationId, int itemId)
        {
            return ReservationItems.FirstOrDefault(r => r.ReservationId == reservationId && r.ItemId == itemId);
        }
    }
}
