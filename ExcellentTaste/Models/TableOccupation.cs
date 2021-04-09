using System;
using ExcellentTaste.Domain.Models;
using ExcellentTaste.Domain.Services;

namespace ExcellentTaste.Models
{
    //used in model TableOccupations
    public class TableOccupation
    {
        public int OrderId { get; set; }
        public int TableId { get; set; }
        public int TableNumber { get; set; }
        public DateTime StartTime { get; set; }
        public int Duration { get; set; }

        public TableOccupation(IFillingData fillingData, ITableData tableData, Order order)
        {
            OrderId = order.Id;
            TableId = order.TableId;
            TableNumber = tableData.Get(TableId).Number;
            StartTime = order.StartTime;
            Filling filling = fillingData.Get(order.FillingId);
            Duration = filling.DurationMinutes + filling.BufferMinutes;
        }
    }
}