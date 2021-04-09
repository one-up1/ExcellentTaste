using System;
using System.Collections.Generic;
using System.Text;
using ExcellentTaste.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ExcellentTaste.Infrastructure.Sql.DbContexts
{
    public class BtwTypeDbContext : DbContext
    {
        public BtwTypeDbContext(DbContextOptions<BtwTypeDbContext> options) : base(options) { }

        public DbSet<BtwType> BtwTypes { get; set; }
    }
}
