using ExcellentTaste.Domain.Models;
using ExcellentTaste.Domain.Services;

namespace ExcellentTaste.Models
{
    //used in model BonDetails
    public class ReservationItemDetail
    {
        public int ReservationId { get; set; }
        public int ItemId { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public float Price { get; set; }

        public ReservationItemDetail(IItemData itemData, IReservationItemData reservationItemData, int reservationId, int itemId)
        {
            ReservationItem reservationItem = reservationItemData.Get(reservationId, itemId);
            ReservationId = reservationId;
            ItemId = itemId;
            Name = itemData.Get(itemId).Name;
            Amount = reservationItem.Amount;
            Price = reservationItem.Price;
        }
    }
}