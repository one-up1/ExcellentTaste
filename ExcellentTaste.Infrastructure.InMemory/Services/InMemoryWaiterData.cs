using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExcellentTaste.Domain.Models;
using ExcellentTaste.Domain.Services;

namespace ExcellentTaste.Infrastructure.InMemory.Services
{
    public class InMemoryWaiterData : IWaiterData
    {
        private readonly List<Waiter> waiters;

        public InMemoryWaiterData()
        {
            waiters = new List<Waiter>() { new Waiter() { Id = 1, Name = "John" }, new Waiter() { Id = 2, Name = "Jane" } };
        }

        public Waiter Get(int waiterId)
        {
            return waiters.FirstOrDefault(w => w.Id == waiterId);
        }

        public IEnumerable<Waiter> GetAll()
        {
            return waiters;
        }
    }
}
