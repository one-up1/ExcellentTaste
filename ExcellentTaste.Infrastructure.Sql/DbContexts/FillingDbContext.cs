using System;
using System.Collections.Generic;
using System.Text;
using ExcellentTaste.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ExcellentTaste.Infrastructure.Sql.DbContexts
{
    public class FillingDbContext : DbContext
    {
        public FillingDbContext(DbContextOptions<FillingDbContext> options) : base(options) { }
        public DbSet<Filling> Fillings { get; set; }
    }
}
