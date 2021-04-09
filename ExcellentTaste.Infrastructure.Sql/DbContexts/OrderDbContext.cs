using System;
using System.Collections.Generic;
using System.Text;
using ExcellentTaste.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ExcellentTaste.Infrastructure.Sql.DbContexts
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options) { }
        public DbSet<Order> Orders { get; set; }
    }
}
