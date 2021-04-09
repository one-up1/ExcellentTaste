using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExcellentTaste.Domain.Models;
using ExcellentTaste.Domain.Services;

namespace ExcellentTaste.Infrastructure.InMemory.Services
{
    public class InMemoryFillingData : IFillingData
    {
        private readonly List<Filling> fillings;

        public InMemoryFillingData()
        {
            fillings = new List<Filling>()
            {
                new Filling(){ Id = 1, Description = "dinner", DurationMinutes = 90, BufferMinutes = 15 },
                new Filling(){ Id = 2, Description = "lunch", DurationMinutes = 45, BufferMinutes = 15}
            };
        }

        public Filling Get(int fillingId)
        {
            return fillings.FirstOrDefault(f => f.Id == fillingId);
        }

        public IEnumerable<Filling> GetAll()
        {
            return fillings;
        }
    }
}
