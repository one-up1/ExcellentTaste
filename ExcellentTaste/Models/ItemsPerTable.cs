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
        public IEnumerable<ItemsOfOrder> Items { get; set; }

        public ItemsPerTable(IOrderData orderData, IOrderItemData orderItemData, ITableData tableData, IItemData itemData, bool prepared, bool delivered, int? stationId = null)
        {
            DateTime today = DateTime.Now;
            IEnumerable<Order> orders = orderData.GetAllOnDay(today.Year, today.Month, today.Day);
            List<ItemsOfOrder> newItems = new List<ItemsOfOrder>();
            foreach(Order order in orders)
            {
                ItemsOfOrder newItemsOfOrder = new ItemsOfOrder(orderItemData, tableData, itemData, order, prepared, delivered, stationId);
                if (newItemsOfOrder.Items.Count() > 0)
                {
                    newItems.Add(newItemsOfOrder);
                }
            }
            Items = newItems;
        }
    }
}
