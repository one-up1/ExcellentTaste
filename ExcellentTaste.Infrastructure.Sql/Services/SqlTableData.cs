using System;
using System.Collections.Generic;
using System.Text;
using ExcellentTaste.Domain;
using ExcellentTaste.Domain.Services;
using ExcellentTaste.Infrastructure.Sql.DbContexts;

namespace ExcellentTaste.Infrastructure.Sql.Services
{
    public class SqlTableData : ITableData
    {
        private readonly TableDbContext db;

        public SqlTableData(TableDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<Table> GetAll()
        {
            return db.Tables;
        }
    }
}
