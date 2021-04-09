using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExcellentTaste.Domain.Models;
using ExcellentTaste.Domain.Services;

namespace ExcellentTaste.Models
{
    //used in model OrderChangeItems
    public class ItemsInCatagory
    {
        public string CatagoryName { get; set; }
        public IEnumerable<Item> Items { get; set; }

        public ItemsInCatagory(ICatagoryData catagoryData, IItemData itemData, int catagoryId)
        {
            CatagoryName = catagoryData.Get(catagoryId).Name;
            Items = itemData.GetAll().Where(i => i.CatagoryId == catagoryId);
        }
    }
}
