using System;
using System.Collections.Generic;
using System.Text;
using ExcellentTaste.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ExcellentTaste.Infrastructure.Sql.DbContexts
{
    public class ItemDbContext : DbContext
    {
        public ItemDbContext(DbContextOptions<ItemDbContext> options) : base(options) { }
        public DbSet<Item> Items{ get; set; }
    }
}
