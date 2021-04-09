using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExcellentTaste.Domain.Models;
using ExcellentTaste.Domain.Services;

namespace ExcellentTaste.Infrastructure.InMemory.Services
{
    public class InMemoryStationData : IStationData
    {
        private readonly List<Station> stations;

        public InMemoryStationData()
        {
            stations = new List<Station>()
            {
                new Station(){ Id = 1, Name = "Bar" },
                new Station(){ Id = 2, Name = "Keuken"}
            };
        }

        public Station Get(int stationId)
        {
            return stations.FirstOrDefault(s => s.Id == stationId);
        }

        public IEnumerable<Station> GetAll()
        {
            return stations;
        }
    }
}
