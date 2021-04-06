using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExcellentTaste.Domain;
using ExcellentTaste.Domain.Services;
using ExcellentTaste.Infrastructure.Sql.DbContexts;

namespace ExcellentTaste.Infrastructure.Sql.Services
{
    class SqlFillingData : IFillingData
    {
        private readonly FillingDbContext db;
        
        public SqlFillingData(FillingDbContext db)
        {
            this.db = db;
        }

        public Filling Get(int fillingId)
        {
            return db.Fillings.FirstOrDefault(f => f.Id == fillingId);
        }

        public IEnumerable<Filling> GetAll()
        {
            return db.Fillings;
        }
    }
}
