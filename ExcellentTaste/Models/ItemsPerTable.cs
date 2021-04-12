using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExcellentTaste.Domain.Models;
using ExcellentTaste.Domain.Services;

namespace ExcellentTaste.Models
{
    //used for waiter picking up prepared items, kitchen/bar preparing items
    public class ItemsPerTable
    {
        public IEnumerable<ItemsOfReservation> Items { get; set; }

        public ItemsPerTable(IReservationData reservationData, IReservationItemData reservationItemData, ITableData tableData, IItemData itemData, bool prepared, bool delivered, int? stationId = null)
        {
            DateTime today = DateTime.Now;
            IEnumerable<Reservation> reservations = reservationData.GetAllOnDay(today.Year, today.Month, today.Day);
            List<ItemsOfReservation> newItems = new List<ItemsOfReservation>();
            foreach(Reservation reservation in reservations)
            {
                ItemsOfReservation newItemsOfReservation = new ItemsOfReservation(reservationItemData, tableData, itemData, reservation, prepared, delivered, stationId);
                if (newItemsOfReservation.Items.Count() > 0)
                {
                    newItems.Add(newItemsOfReservation);
                }
            }
            Items = newItems;
        }
    }
}
