using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExcellentTaste.Domain;
using ExcellentTaste.Domain.Models;
using ExcellentTaste.Domain.Services;

namespace ExcellentTaste.Models
{
    //used to create the Bon
    public class ReceiptDetails
    {
        public string Waitername { get; set; }
        public DateTime StartTime { get; set; }
        public int TableNumber { get; set; }
        public IEnumerable<ReservationItemDetail> reservationItems { get; set; }
        public IEnumerable<BtwType> BtwTypes { get; set; }

        public ReceiptDetails(IBtwTypeData btwTypeData, IItemData itemData, IReservationData reservationData, IReservationItemData reservationItemData, ITableData tableData, IWaiterData waiterData, int reservationId)
        {
            Reservation reservation = reservationData.Get(reservationId);
            Waitername = waiterData.Get(reservation.WaitorId).Name;

            StartTime = reservation.StartTime;

            TableNumber = tableData.Get(reservation.TableId).Number;

            List<ReservationItemDetail> newReservationItems = new List<ReservationItemDetail>();
            IEnumerable<ReservationItem> reservationItems = reservationItemData.Get(reservationId);
            foreach(ReservationItem reservationItem in reservationItems)
            {
                newReservationItems.Add(new ReservationItemDetail(itemData, reservationItemData, reservationItem.ReservationId, reservationItem.ItemId));
            }
            this.reservationItems = newReservationItems;

            BtwTypes = btwTypeData.GetAll();
        }
    }
}
