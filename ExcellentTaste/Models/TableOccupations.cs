using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ExcellentTaste.Domain.Models;
using ExcellentTaste.Domain.Services;

namespace ExcellentTaste.Models
{
    //used for users to get a overview of table occupations, waiter to assign table, overview of tables. used in OrdersTables
    public class TableOccupations
    {
        private const int minutesInHour = 60;

        public IEnumerable<TableOccupation> Occupations { get; set; }

        public TableOccupations(IFillingData fillingData, IOrderData orderData, ITableData tableData, int year, int month, int day)
        {
            IEnumerable<Order> orders = orderData.GetAllOnDay(year, month, day);
            ConstructorHelper(fillingData, tableData, orders);
        }
        public TableOccupations(IFillingData fillingData, IOrderData orderData, ITableData tableData)
        {
            IEnumerable<Order> orders = orderData.GetAllButOld();
            ConstructorHelper(fillingData, tableData, orders);
        }
        private TableOccupations(IFillingData fillingData, ITableData tableData, IEnumerable<Order> orders)
        {
            ConstructorHelper(fillingData, tableData, orders);
        }
        private void ConstructorHelper(IFillingData fillingData, ITableData tableData, IEnumerable<Order> orders)
        {
            List<TableOccupation> newOccupations = new List<TableOccupation>();
            foreach(Order order in orders)
            {
                newOccupations.Add(new TableOccupation(fillingData, tableData, order));
            }
            Occupations = newOccupations;
        }

        public static TableOccupations GetActiveOccupations(IFillingData fillingData, IOrderData orderData, ITableData tableData)
        {
            DateTime now = DateTime.Now;
            int nowMinute = now.Hour * minutesInHour + now.Minute;

            Func<Filling, Order, bool> isActive = (Filling filling, Order order) =>
            {
                int orderStartMinute = order.StartTime.Hour * minutesInHour + order.StartTime.Minute;
                return orderStartMinute <= nowMinute && orderStartMinute + filling.DurationMinutes + filling.BufferMinutes >= nowMinute;
            };
            IEnumerable<Order> orders = orderData.GetAllOnDay(now.Year, now.Month, now.Day).Where(o => isActive(fillingData.Get(o.FillingId), o));
            return new TableOccupations(fillingData, tableData, orders);
        }
    }
}