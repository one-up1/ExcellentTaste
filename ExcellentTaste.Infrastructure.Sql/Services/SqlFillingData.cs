using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExcellentTaste.Domain.Models;
using ExcellentTaste.Domain.Services;
using ExcellentTaste.Infrastructure.Sql.DbContexts;

namespace ExcellentTaste.Infrastructure.Sql.Services
{
    public class SqlFillingData : IFillingData
    {
        private readonly ExcellentTasteContext db;
        
        public SqlFillingData(ExcellentTasteContext db)
        {
            this.db = db;
        }

        public Filling Get(int fillingId)
        {
            return db.Fillings.Find(fillingId);
        }

        public IEnumerable<Filling> GetAll()
        {
            return db.Fillings;
        }
    }
}
