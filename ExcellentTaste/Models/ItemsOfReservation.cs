using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using System.Web.Mvc;
using Microsoft.Extensions.DependencyInjection;
using ExcellentTaste.Domain.Models;
using ExcellentTaste.Domain.Services;

namespace ExcellentTaste.Models
{
    //used for waiter to pick up, kok/bar to prepare
    public class ItemsOfReservation
    {
        public int TableNumber { get; set; }
        public IEnumerable<ReservationItemDetail> Items { get; set; }

        public ItemsOfReservation(IReservationItemData reservationItemData, ITableData tableData, IItemData itemData, Reservation reservation, bool prepared, bool delivered, int? stationId = null)
        {
            TableNumber = tableData.Get(reservation.TableId).Number;

            List<ReservationItemDetail> newItems = new List<ReservationItemDetail>();
            IEnumerable<ReservationItem> reservationItems = reservationItemData.Get(reservation.Id).Where(o => o.Prepared == prepared && o.Delivered == delivered);
            foreach(ReservationItem reservationItem in reservationItems)
            {
                if(stationId != null)
                {
                    if (itemData.Get(reservationItem.ItemId).StationId == stationId)
                    {
                        newItems.Add(new ReservationItemDetail(itemData, reservationItemData, reservation.Id, reservationItem.ItemId));
                    }
                }
                else
                {
                    newItems.Add(new ReservationItemDetail(itemData, reservationItemData, reservation.Id, reservationItem.ItemId));
                }
            }
            Items = newItems;
        }
        public ItemsOfReservation(IReservationItemData reservationItemData, ITableData tableData, IItemData itemData, Reservation reservation):this(reservationItemData, tableData, itemData, reservation, true, false)
        {

        }
        public ItemsOfReservation(IReservationItemData reservationItemData, ITableData tableData, Reservation reservation, int stationId):this(reservationItemData, tableData, null, reservation, false, false, stationId)
        {

        }
    }
}
