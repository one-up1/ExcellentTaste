using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExcellentTaste.Domain.Models;
using ExcellentTaste.Domain.Services;

namespace ExcellentTaste.Infrastructure.InMemory.Services
{
    public class InMemoryReservationData : IReservationData
    {
        private readonly List<Reservation> reservations;

        public InMemoryReservationData()
        {
            reservations = new List<Reservation>()
            {
                new Reservation(){ Id = 1, StartTime = new DateTime(2021, 6, 10, 18, 30, 0), TableId = 1, FillingId = 1, WaitorId = 1, Completed = false},
                new Reservation(){ Id = 2, StartTime = new DateTime(2021, 6, 10, 13, 00, 0), TableId = 2, FillingId = 2, WaitorId = 2, Completed = true}
            };
        }

        public void Create(Reservation newReservation)
        {
            reservations.Add(newReservation);
        }

        public void Edit(Reservation editedReservation)
        {
            for (int i = 0; i < reservations.Count; i++)
            {
                if (reservations[i].Id == editedReservation.Id)
                {
                    reservations[i] = editedReservation;
                    return;
                }
            }
        }

        public Reservation Get(int reservationId)
        {
            return reservations.FirstOrDefault(r => r.Id == reservationId);
        }

        public IEnumerable<Reservation> GetAll()
        {
            return reservations;
        }

        public IEnumerable<Reservation> GetAllButOld()
        {
            DateTime currentDatetime = DateTime.Now;
            return reservations.Where(r => r.StartTime.Year >= currentDatetime.Year && r.StartTime.Month >= currentDatetime.Month && r.StartTime.Day >= currentDatetime.Day);
        }

        public IEnumerable<Reservation> GetAllOnDay(int year, int month, int day)
        {
            return reservations.Where(r => r.StartTime.Year == year && r.StartTime.Month == month && r.StartTime.Day == day);
        }
    }
}
