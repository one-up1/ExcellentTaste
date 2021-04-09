using ExcellentTaste.Domain.Models;
using ExcellentTaste.Domain.Services;

namespace ExcellentTaste.Models
{
    // used in model OrdersTables
    public class OrderTable
    {
        public int OrderId { get; set; }
        public int TableNumber { get; set; }

        public OrderTable(ITableData tableData, int orderId, int tableId)
        {
            OrderId = orderId;
            TableNumber = tableData.Get(tableId).Number;
        }
    }
}