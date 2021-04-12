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
    public class ItemsOfOrder
    {
        public int TableNumber { get; set; }
        public IEnumerable<OrderItemDetail> Items { get; set; }

        public ItemsOfOrder(IOrderItemData orderItemData, ITableData tableData, IItemData itemData, Order order, bool prepared, bool delivered, int? stationId = null)
        {
            TableNumber = tableData.Get(order.TableId).Number;

            List<OrderItemDetail> newItems = new List<OrderItemDetail>();
            IEnumerable<OrderItem> orderItems = orderItemData.Get(order.Id).Where(o => o.Prepared == prepared && o.Delivered == delivered);
            foreach(OrderItem orderItem in orderItems)
            {
                if(stationId != null)
                {
                    if (itemData.Get(orderItem.ItemId).StationId == stationId)
                    {
                        newItems.Add(new OrderItemDetail(itemData, orderItemData, order.Id, orderItem.ItemId));
                    }
                }
                else
                {
                    newItems.Add(new OrderItemDetail(itemData, orderItemData, order.Id, orderItem.ItemId));
                }
            }
            Items = newItems;
        }
        public ItemsOfOrder(IOrderItemData orderItemData, ITableData tableData, IItemData itemData, Order order):this(orderItemData, tableData, itemData, order, true, false)
        {

        }
        public ItemsOfOrder(IOrderItemData orderItemData, ITableData tableData, Order order, int stationId):this(orderItemData, tableData, null, order, false, false, stationId)
        {

        }
    }
}
