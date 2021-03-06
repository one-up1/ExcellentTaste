using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExcellentTaste.Domain.Models;
using ExcellentTaste.Domain.Services;

namespace ExcellentTaste.Infrastructure.InMemory.Services
{
    public class InMemoryBtwTypeData : IBtwTypeData
    {
        private readonly List<BtwType> btwTypes;

        public InMemoryBtwTypeData()
        {
            btwTypes = new List<BtwType>()
            {
                new BtwType() { Id = 1, Name = "hoog", Percentage = 21 },
                new BtwType() { Id = 2, Name = "laag", Percentage = 9 }
            };
        }

        public BtwType Get(int btwTypeId)
        {
            return btwTypes.FirstOrDefault(b => b.Id == btwTypeId);
        }

        public IEnumerable<BtwType> GetAll()
        {
            return btwTypes;
        }
    }
}
