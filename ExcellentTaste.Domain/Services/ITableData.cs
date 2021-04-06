using System;
using System.Collections.Generic;
using System.Text;

namespace ExcellentTaste.Domain.Services
{
    public interface ITableData
    {
        IEnumerable<Table> GetAll();
    }
}
