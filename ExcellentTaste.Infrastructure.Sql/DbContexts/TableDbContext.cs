
using System;
using System.Collections.Generic;
using System.Text;
using ExcellentTaste.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ExcellentTaste.Infrastructure.Sql.DbContexts
{
    public class TableDbContext : DbContext
    {
        public TableDbContext(DbContextOptions<TableDbContext> options) : base(options) { }
        public DbSet<Table> Tables { get; set; }
    }
}
