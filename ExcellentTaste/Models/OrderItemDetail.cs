using ExcellentTaste.Domain.Models;
using ExcellentTaste.Domain.Services;

namespace ExcellentTaste.Models
{
    //used in model BonDetails
    public class OrderItemDetail
    {
        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public float Price { get; set; }

        public OrderItemDetail(IItemData itemData, IOrderItemData orderItemData, int orderId, int itemId)
        {
            OrderItem orderItem = orderItemData.Get(orderId, itemId);
            OrderId = orderId;
            ItemId = itemId;
            Name = itemData.Get(itemId).Name;
            Amount = orderItem.Amount;
            Price = orderItem.Price;
        }
    }
}