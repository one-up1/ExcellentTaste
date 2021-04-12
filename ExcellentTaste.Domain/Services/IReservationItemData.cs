using System;
using System.Collections.Generic;
using System.Text;
using ExcellentTaste.Domain.Models;

namespace ExcellentTaste.Domain.Services
{
    public interface IReservationItemData
    {
        IEnumerable<ReservationItem> Get(int reservationId);
        ReservationItem Get(int reservationId, int itemId);
        void Edit(ReservationItem editedReservationItem);
        void Create(ReservationItem newReservationItem);
        void Delete(int reservationItemToRemoveReservationId, int reservationItemToRemoveItemId);
    }
}
