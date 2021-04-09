using System;
using System.Collections.Generic;
using System.Text;
using ExcellentTaste.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ExcellentTaste.Infrastructure.Sql.DbContexts
{
    public class OrderItemDbContext : DbContext
    {
        public OrderItemDbContext(DbContextOptions<OrderItemDbContext> options) : base(options) { }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}
