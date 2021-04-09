using System;
using System.Collections.Generic;
using System.Text;
using ExcellentTaste.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ExcellentTaste.Infrastructure.Sql.DbContexts
{
    public class StationDbContext : DbContext
    {
        public StationDbContext(DbContextOptions<StationDbContext> options) : base(options) { }
        public DbSet<Station> Stations { get; set; }
    }
}
