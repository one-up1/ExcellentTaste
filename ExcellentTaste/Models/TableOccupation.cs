using System;
using ExcellentTaste.Domain.Models;
using ExcellentTaste.Domain.Services;

namespace ExcellentTaste.Models
{
    //used in model TableOccupations
    public class TableOccupation
    {
        public int ReservationId { get; set; }
        public int TableId { get; set; }
        public int TableNumber { get; set; }
        public DateTime StartTime { get; set; }
        public int Duration { get; set; }

        public TableOccupation(IFillingData fillingData, ITableData tableData, Reservation reservation)
        {
            ReservationId = reservation.Id;
            TableId = reservation.TableId;
            TableNumber = tableData.Get(TableId).Number;
            StartTime = reservation.StartTime;
            Filling filling = fillingData.Get(reservation.FillingId);
            Duration = filling.DurationMinutes + filling.BufferMinutes;
        }
    }
}