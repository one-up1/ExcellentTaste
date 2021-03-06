using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExcellentTaste.Domain.Models;
using ExcellentTaste.Domain.Services;

namespace ExcellentTaste.Models
{
    //used for waiter picking up new items in a reservation
    public class ReservationChangeItems
    {
        public int ReservationId { get; set; }
        public IEnumerable<ReservationItem> ReservationItems { get; set; }
        public IEnumerable<ItemsInCatagory> ItemsPerCatagory { get; set; }

        public ReservationChangeItems(ICatagoryData catagoryData, IItemData itemData, IReservationItemData reservationItemData, int reservationId)
        {
            ReservationId = reservationId;
            ReservationItems = reservationItemData.Get(reservationId);
            IEnumerable<Catagory> catagories = catagoryData.GetAll();
            List<ItemsInCatagory> newItemsPerCatagory = new List<ItemsInCatagory>();
            foreach(Catagory catagory in catagories)
            {
                ItemsInCatagory newItemsInCatory = new ItemsInCatagory(catagoryData, itemData, catagory.Id);
                if(newItemsInCatory.Items.Count() > 0)
                {
                    newItemsPerCatagory.Add(newItemsInCatory);
                }
            }
            ItemsPerCatagory = newItemsPerCatagory;
        }
    }
}
