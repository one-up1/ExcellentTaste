using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using ExcellentTaste.Domain;

namespace ExcellentTaste.Infrastructure.Sql.DbContexts
{
    public class FillingDbContext : DbContext
    {
        public DbSet<Filling> Fillings { get; set; }
    }
}
