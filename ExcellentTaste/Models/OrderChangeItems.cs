using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExcellentTaste.Domain.Models;
using ExcellentTaste.Domain.Services;

namespace ExcellentTaste.Models
{
    //used for waiter picking up new items in an order
    public class OrderChangeItems
    {
        public int OrderId { get; set; }
        public IEnumerable<OrderItem> OrderItems { get; set; }
        public IEnumerable<ItemsInCatagory> ItemsPerCatagory { get; set; }

        public OrderChangeItems(ICatagoryData catagoryData, IItemData itemData, IOrderItemData orderItemData, int orderId)
        {
            OrderId = orderId;
            OrderItems = orderItemData.Get(orderId);
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
