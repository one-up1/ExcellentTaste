using System;
using System.Collections.Generic;
using System.Text;
using ExcellentTaste.Domain.Models;
using ExcellentTaste.Domain.Services;

namespace ExcellentTaste.Infrastructure.InMemory.Services
{
    class InMemoryStationData : IStationData
    {
        private List<Station> stations;

        public InMemoryStationData()
        {
            stations = new List<Station>()
            {
                new Station(){ Id = 1, Name = "Bar" },
                new Station(){ Id = 2, Name = "Keuken"}
            }
        }

        public Station Get(int stationId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Station> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
