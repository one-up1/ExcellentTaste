using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExcellentTaste.Domain.Models;
using ExcellentTaste.Domain.Services;

namespace ExcellentTaste.Models
{
    //used for the administrator overview
    public class ItemDetails
    {
        public IEnumerable<ItemDetail> Items { get; set; }

        public ItemDetails(IBtwTypeData btwTypeData, ICatagoryData catagoryData, IItemData itemData)
        {
            /*
            IItemData itemData = DependencyResolver.Current.GetService<IItemData>();
            */

            IEnumerable<Item> items = itemData.GetAll();

            List<ItemDetail> newItems = new List<ItemDetail>();
            foreach(Item item in items)
            {
                newItems.Add(new ItemDetail(btwTypeData, catagoryData, itemData, item.Id));
            }
            Items = newItems;
        }
    }
}
