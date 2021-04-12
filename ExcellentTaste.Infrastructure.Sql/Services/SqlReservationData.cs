using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExcellentTaste.Domain.Models;
using ExcellentTaste.Domain.Services;
using ExcellentTaste.Infrastructure.Sql.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace ExcellentTaste.Infrastructure.Sql.Services
{
    public class SqlReservationData : IReservationData
    {
        private readonly ReservationDbContext db;

        public SqlReservationData(ReservationDbContext db)
        {
            this.db = db;
        }

        public void Create(Reservation newReservation)
        {
            var entry = db.Add(newReservation);
            entry.State = EntityState.Added;
            db.SaveChanges();
        }

        public void Edit(Reservation editedReservation)
        {
            var entry = db.Attach(editedReservation);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }

        public Reservation Get(int ReservationId)
        {
            return db.Reservations.Find(ReservationId);
        }

        public IEnumerable<Reservation> GetAll()
        {
            return db.Reservations;
        }

        public IEnumerable<Reservation> GetAllButOld()
        {
            DateTime currentDatetime = DateTime.Now;
            return db.Reservations.Where(o => o.StartTime.Year >= currentDatetime.Year && o.StartTime.Month >= currentDatetime.Month && o.StartTime.Day >= currentDatetime.Day);
        }

        public IEnumerable<Reservation> GetAllOnDay(int year, int month, int day)
        {
            return db.Reservations.Where(o => o.StartTime.Year == year && o.StartTime.Month == month && o.StartTime.Day == day);
        }
    }
}
