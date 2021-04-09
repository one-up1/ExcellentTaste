using System;
using System.Collections.Generic;
using System.Text;
using ExcellentTaste.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ExcellentTaste.Infrastructure.Sql.DbContexts
{
    public class WaiterDbContext : DbContext
    {
        public WaiterDbContext(DbContextOptions<WaiterDbContext> options) : base(options) { }
        public DbSet<Waiter> Waiters { get; set; }
    }
}
