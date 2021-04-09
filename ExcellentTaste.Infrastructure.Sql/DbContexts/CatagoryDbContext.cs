using System;
using System.Collections.Generic;
using System.Text;
using ExcellentTaste.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ExcellentTaste.Infrastructure.Sql.DbContexts
{
    public class CatagoryDbContext : DbContext
    {
        public CatagoryDbContext(DbContextOptions<CatagoryDbContext> options) : base(options) { }
        public DbSet<Catagory> Catagories { get; set; }
    }
}
