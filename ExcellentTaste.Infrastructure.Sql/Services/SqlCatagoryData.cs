using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExcellentTaste.Domain;
using ExcellentTaste.Domain.Services;
using ExcellentTaste.Infrastructure.Sql.DbContexts;

namespace ExcellentTaste.Infrastructure.Sql.Services
{
    class SqlCatagoryData : ICatagoryData
    {
        private readonly CatagoryDbContext db;

        public SqlCatagoryData(CatagoryDbContext db)
        {
            this.db = db;
        }

        public Catagory Get(int catagoryId)
        {
            return db.Catagories.FirstOrDefault(c => c.Id == catagoryId);
        }

        public IEnumerable<Catagory> GetAll()
        {
            return db.Catagories;
        }
    }
}
