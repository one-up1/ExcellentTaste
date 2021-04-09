using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExcellentTaste.Domain.Models;
using ExcellentTaste.Domain.Services;

namespace ExcellentTaste.Models
{
    //used for the administrator remove and detail. in model ItemDetails
    public class ItemDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public int BtwPercentage { get; set; }
        public string CatagoryName { get; set; }
        public bool Available { get; set; }

        public ItemDetail(IBtwTypeData btwTypeData, ICatagoryData catagoryData, IItemData itemData, int itemId)
        {
            /*
            IBtwTypeData btwTypeData = DependencyResolver.Current.GetService<IBtwTypeData>();
            ICatagoryData catagoryData = DependencyResolver.Current.GetService<ICatagoryData>();
            IItemData itemData = DependencyResolver.Current.GetService<IItemData>();
            */

            Item item = itemData.Get(itemId);

            Id = itemId;
            Name = item.Name;
            Description = item.Description;
            Price = item.Price;
            BtwPercentage = btwTypeData.Get(item.BtwTypeId).Percentage;
            CatagoryName = catagoryData.Get(item.CatagoryId).Name;
            Available = item.Available;
        }
    }
}
