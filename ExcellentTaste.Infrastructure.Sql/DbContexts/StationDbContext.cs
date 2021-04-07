using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using ExcellentTaste.Domain.Models;

namespace ExcellentTaste.Infrastructure.Sql.DbContexts
{
    public class StationDbContext : DbContext
    {
        public DbSet<Station> Stations { get; set; }
    }
}
