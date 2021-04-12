using System;
using System.Collections.Generic;
using System.Text;
using ExcellentTaste.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ExcellentTaste.Infrastructure.Sql.DbContexts
{
    public class ReservationItemDbContext : DbContext
    {
        public ReservationItemDbContext(DbContextOptions<ReservationItemDbContext> options) : base(options) { }
        public DbSet<ReservationItem> ReservationItems { get; set; }
    }
}
