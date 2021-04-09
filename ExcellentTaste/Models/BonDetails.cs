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
    public class BonDetails
    {
        public string Waitername { get; set; }
        public DateTime StartTime { get; set; }
        public int TableNumber { get; set; }
        public IEnumerable<OrderItemDetail> OrderItems { get; set; }
        public IEnumerable<BtwType> BtwTypes { get; set; }

        public BonDetails(IBtwTypeData btwTypeData, IItemData itemData, IOrderData orderData, IOrderItemData orderItemData, ITableData tableData, IWaiterData waiterData, int orderId)
        {
            /*
            IBtwTypeData btwTypeData = DependencyResolver.Current.GetService<IBtwTypeData>();
            IOrderData orderData = DependencyResolver.Current.GetService<IOrderData>();
            IOrderItemData orderItemData = DependencyResolver.Current.GetService<IOrderItemData>();
            ITableData tableData = DependencyResolver.Current.GetService<ITableData>();
            IWaiterData waiterData = DependencyResolver.Current.GetService<IWaiterData>();
            */

            Order order = orderData.Get(orderId);
            Waitername = waiterData.Get(order.WaitorId).Name;

            StartTime = order.StartTime;

            TableNumber = tableData.Get(order.TableId).Number;

            List<OrderItemDetail> newOrderItems = new List<OrderItemDetail>();
            IEnumerable<OrderItem> orderItems = orderItemData.Get(orderId);
            foreach(OrderItem orderItem in orderItems)
            {
                newOrderItems.Add(new OrderItemDetail(itemData, orderItemData, orderItem.OrderId, orderItem.ItemId));
            }
            OrderItems = newOrderItems;

            BtwTypes = btwTypeData.GetAll();
        }
    }
}
