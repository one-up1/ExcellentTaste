using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using ExcellentTaste.Domain;

namespace ExcellentTaste.Infrastructure.Sql.DbContexts
{
    public class OrderDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
    }
}
