using System;
using System.Collections.Generic;
using System.Text;
using ExcellentTaste.Domain.Models;

namespace ExcellentTaste.Domain.Services
{
    public interface IReservationData
    {
        IEnumerable<Reservation> GetAll();
        IEnumerable<Reservation> GetAllButOld();
        IEnumerable<Reservation> GetAllOnDay(int year, int month, int day);
        Reservation Get(int reservationId);
        void Create(Reservation newReservation);
        void Edit(Reservation editedReservation);
    }
}
