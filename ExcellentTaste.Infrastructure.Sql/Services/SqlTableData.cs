using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExcellentTaste.Domain;
using ExcellentTaste.Domain.Models;
using ExcellentTaste.Domain.Services;
using ExcellentTaste.Infrastructure.Sql.DbContexts;

namespace ExcellentTaste.Infrastructure.Sql.Services
{
    public class SqlTableData : ITableData
    {
        private readonly ExcellentTasteContext db;

        public SqlTableData(ExcellentTasteContext db)
        {
            this.db = db;
        }

        public Table Get(int tableId)
        {
            return db.Tables.Find(tableId);
        }

        public IEnumerable<Table> GetAll()
        {
            return db.Tables;
        }
    }
}
