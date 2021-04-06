using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using ExcellentTaste.Domain;

namespace ExcellentTaste.Infrastructure.Sql.DbContexts
{
    public class OrderItemDbContext : DbContext
    {
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}
