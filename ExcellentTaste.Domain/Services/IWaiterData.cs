using System;
using System.Collections.Generic;
using System.Text;

namespace ExcellentTaste.Domain.Services
{
    public interface IWaiterData
    {
        IEnumerable<Waiter> GetAll();
        Waiter Get(int waiterId);
    }
}
