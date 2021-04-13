using System;
using System.Collections.Generic;
using System.Text;
using ExcellentTaste.Domain.Models;
using ExcellentTaste.Domain.Services;
using ExcellentTaste.Infrastructure.Sql.DbContexts;

namespace ExcellentTaste.Infrastructure.Sql.Services
{
    public class SqlBtwTypeData : IBtwTypeData
    {
        private readonly ExcellentTasteContext db;

        public SqlBtwTypeData(ExcellentTasteContext db)
        {
            this.db = db;
        }

        public BtwType Get(int btwTypeId)
        {
            return db.BtwTypes.Find(btwTypeId);
        }

        public IEnumerable<BtwType> GetAll()
        {
            return db.BtwTypes;
        }
    }
}
