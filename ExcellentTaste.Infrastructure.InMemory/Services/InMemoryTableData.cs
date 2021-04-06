using System;
using System.Collections.Generic;
using System.Text;
using ExcellentTaste.Domain;
using ExcellentTaste.Domain.Services;

namespace ExcellentTaste.Infrastructure.InMemory.Services
{
    public class InMemoryTableData : ITableData
    {
        private List<Table> tables;

        public InMemoryTableData()
        {
            tables = new List<Table>() { new Table() { Id = 1 }, new Table() { Id = 2 } };
        }

        public IEnumerable<Table> GetAll()
        {
            return tables;
        }
    }
}
