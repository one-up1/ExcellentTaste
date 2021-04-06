using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using ExcellentTaste.Domain;

namespace ExcellentTaste.Infrastructure.Sql.DbContexts
{
    public class ItemDbContext : DbContext
    {
        public DbSet<Item> Items{ get; set; }
    }
}
