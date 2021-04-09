using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExcellentTaste.Domain.Models;
using ExcellentTaste.Domain.Services;

namespace ExcellentTaste.Models
{
    //used for administrator create and edit
    public class ItemEdit
    {
        public Item ActiveItem { get; set; }
        public ItemOptions Options { get; set; }

        public ItemEdit(IBtwTypeData btwTypeData, ICatagoryData catagoryData, IStationData stationData, Item itemToEdit = null)
        {
            if(itemToEdit == null)
            {
                ActiveItem = new Item();
            }
            else
            {
                ActiveItem = itemToEdit;
            }
            Options = new ItemOptions(btwTypeData, catagoryData, stationData);
        }
    }
}
