
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using ExcellentTaste.Domain;

namespace ExcellentTaste.Infrastructure.Sql.DbContexts
{
    public class TableDbContext : DbContext
    {
        public DbSet<Table> Tables { get; set; }
    }
}
