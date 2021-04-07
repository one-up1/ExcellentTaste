using System;
using System.Collections.Generic;
using System.Text;
using ExcellentTaste.Domain.Models;

namespace ExcellentTaste.Domain.Services
{
    public interface IStationData
    {
        IEnumerable<Station> GetAll();
        Station Get(int stationId);
    }
}
