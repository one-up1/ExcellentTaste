using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExcellentTaste.Domain.Models;
using ExcellentTaste.Domain.Services;
using ExcellentTaste.Infrastructure.Sql.DbContexts;

namespace ExcellentTaste.Infrastructure.Sql.Services
{
    public class SqlStationData : IStationData
    {
        private readonly ExcellentTasteContext db;

        public SqlStationData(ExcellentTasteContext db)
        {
            this.db = db;
        }

        public Station Get(int stationId)
        {
            return db.Stations.Find(stationId);
        }

        public IEnumerable<Station> GetAll()
        {
            return db.Stations;
        }
    }
}
