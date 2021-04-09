using System;
using System.Collections.Generic;
using System.Text;
using ExcellentTaste.Domain.Models;

namespace ExcellentTaste.Domain.Services
{
    public interface ITableData
    {
        IEnumerable<Table> GetAll();
        Table Get(int tableId);
    }
}
