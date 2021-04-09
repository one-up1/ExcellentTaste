using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExcellentTaste.Domain.Services;

namespace ExcellentTaste.Models
{
    //used for waiter overview of tables
    public class OrdersTables
    {
        private const int minutesInHour = 60;

        public IEnumerable<OrderTable> Orders { get; set; }

        public OrdersTables(IFillingData fillingData, IOrderData orderData, ITableData tableData)
        {
            DateTime now = DateTime.Now;
            int nowMinute = now.Hour * minutesInHour + now.Minute;
            TableOccupations tableAvailabilities = new TableOccupations(fillingData, orderData, tableData, now.Year, now.Month, now.Day);
            List<OrderTable> newOrders = new List<OrderTable>();            
            foreach(TableOccupation tableOccupation in tableAvailabilities.Occupations)
            {
                int orderStartMinute = tableOccupation.StartTime.Hour * minutesInHour + tableOccupation.StartTime.Minute;
                if (orderStartMinute <= nowMinute && orderStartMinute + tableOccupation.Duration >= nowMinute)
                {
                    //newOrders.Add(new OrderTable(tableData, tableOccupation.OrderId, tableOccupation.));
                }
            }
            Orders = newOrders;
        }
    }
}
