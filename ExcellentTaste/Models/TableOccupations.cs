using System;
using System.Collections;
using System.Collections.Generic;
using ExcellentTaste.Domain.Models;
using ExcellentTaste.Domain.Services;

namespace ExcellentTaste.Models
{
    //used for users to get a overview of table occupations, waiter to assign table, used in OrdersTables
    public class TableOccupations
    {
        public IEnumerable<TableOccupation> Occupations { get; set; }

        public TableOccupations(IFillingData fillingData, IOrderData orderData, ITableData tableData, int year, int month, int day)
        {
            IEnumerable<Order> orders = orderData.GetAllOnDay(year, month, day);
            constructorHelper(fillingData, tableData, orders);
        }
        public TableOccupations(IFillingData fillingData, IOrderData orderData, ITableData tableData)
        {
            IEnumerable<Order> orders = orderData.GetAllButOld();
            constructorHelper(fillingData, tableData, orders);
        }
        private void constructorHelper(IFillingData fillingData, ITableData tableData, IEnumerable<Order> orders)
        {
            List<TableOccupation> newOccupations = new List<TableOccupation>();
            foreach(Order order in orders)
            {
                newOccupations.Add(new TableOccupation(fillingData, tableData, order));
            }
            Occupations = newOccupations;
        }
    }
}