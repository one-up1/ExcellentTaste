using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExcellentTaste.Domain.Models;
using ExcellentTaste.Domain.Services;
using ExcellentTaste.Infrastructure.Sql.DbContexts;

namespace ExcellentTaste.Infrastructure.Sql.Services
{
    public class SqlWaiterData : IWaiterData
    {
        private readonly WaiterDbContext db;

        public SqlWaiterData(WaiterDbContext db)
        {
            this.db = db;
        }

        public Waiter Get(int waiterId)
        {
            return db.Waiters.Find(waiterId);
        }

        public IEnumerable<Waiter> GetAll()
        {
            return db.Waiters;
        }
    }
}
