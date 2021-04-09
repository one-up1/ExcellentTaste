using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExcellentTaste.Domain.Models;
using ExcellentTaste.Domain.Services;

namespace ExcellentTaste.Models
{
    //used in model ItemEdit
    public class ItemOptions
    {
        public IEnumerable<BtwType> BtwTypes { get; set; }
        public IEnumerable<Catagory> Catagories { get; set; }
        public IEnumerable<Station> Stations { get; set; }

        public ItemOptions(IBtwTypeData btwTypeData, ICatagoryData catagoryData, IStationData stationData)
        {
            /*
            IBtwTypeData btwTypeData = DependencyResolver.Current.GetService<IBtwTypeData>();
            ICatagoryData catagoryData = DependencyResolver.Current.GetService<ICatagoryData>();
            IStationData stationData = DependencyResolver.Current.GetService<IStationData>();
            */

            BtwTypes = btwTypeData.GetAll();
            Catagories = catagoryData.GetAll();
            Stations = stationData.GetAll();
        }
    }
}
