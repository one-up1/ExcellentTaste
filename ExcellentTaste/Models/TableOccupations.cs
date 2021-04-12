using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ExcellentTaste.Domain.Models;
using ExcellentTaste.Domain.Services;

namespace ExcellentTaste.Models
{
    //used for users to get a overview of table occupations, waiter to assign table, overview of tables.
    public class TableOccupations
    {
        private const int minutesInHour = 60;

        public IEnumerable<TableOccupation> Occupations { get; set; }

        public TableOccupations(IFillingData fillingData, IReservationData reservationData, ITableData tableData, int year, int month, int day)
        {
            IEnumerable<Reservation> reservations = reservationData.GetAllOnDay(year, month, day);
            ConstructorHelper(fillingData, tableData, reservations);
        }
        public TableOccupations(IFillingData fillingData, IReservationData reservationData, ITableData tableData)
        {
            IEnumerable<Reservation> reservations = reservationData.GetAllButOld();
            ConstructorHelper(fillingData, tableData, reservations);
        }
        private TableOccupations(IFillingData fillingData, ITableData tableData, IEnumerable<Reservation> reservations)
        {
            ConstructorHelper(fillingData, tableData, reservations);
        }
        private void ConstructorHelper(IFillingData fillingData, ITableData tableData, IEnumerable<Reservation> reservations)
        {
            List<TableOccupation> newOccupations = new List<TableOccupation>();
            foreach(Reservation reservation in reservations)
            {
                newOccupations.Add(new TableOccupation(fillingData, tableData, reservation));
            }
            Occupations = newOccupations;
        }

        public static TableOccupations GetActiveOccupations(IFillingData fillingData, IReservationData reservationData, ITableData tableData)
        {
            DateTime now = DateTime.Now;
            int nowMinute = now.Hour * minutesInHour + now.Minute;

            Func<Filling, Reservation, bool> isActive = (Filling filling, Reservation reservation) =>
            {
                int reservationStartMinute = reservation.StartTime.Hour * minutesInHour + reservation.StartTime.Minute;
                return reservationStartMinute <= nowMinute && reservationStartMinute + filling.DurationMinutes + filling.BufferMinutes >= nowMinute;
            };
            IEnumerable<Reservation> reservations = reservationData.GetAllOnDay(now.Year, now.Month, now.Day).Where(o => isActive(fillingData.Get(o.FillingId), o));
            return new TableOccupations(fillingData, tableData, reservations);
        }
    }
}