using System;
using System.Collections.Generic;
using System.Text;
using ExcellentTaste.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ExcellentTaste.Infrastructure.Sql.DbContexts
{
    public class ExcellentTasteContext : DbContext
    {
        public ExcellentTasteContext(DbContextOptions<ExcellentTasteContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReservationItem>().HasKey(r => new { r.ReservationId, r.ItemId });
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<BtwType> BtwTypes { get; set; }
        public DbSet<Catagory> Catagories { get; set; }
        public DbSet<Filling> Fillings { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<ReservationItem> ReservationItems { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Waiter> Waiters { get; set; }
    }
}
