using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExcellentTaste.Domain.Models;
using ExcellentTaste.Domain.Services;

namespace ExcellentTaste.Infrastructure.InMemory.Services
{
    public class InMemoryTableData : ITableData
    {
        private readonly List<Table> tables;

        public InMemoryTableData()
        {
            tables = new List<Table>() { new Table() { Id = 1 }, new Table() { Id = 2 } };
        }

        public Table Get(int tableId)
        {
            return tables.FirstOrDefault(t => t.Id == tableId);
        }

        public IEnumerable<Table> GetAll()
        {
            return tables;
        }
    }
}
