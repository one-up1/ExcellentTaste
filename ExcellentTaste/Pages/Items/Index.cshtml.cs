using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExcellentTaste.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ExcellentTaste.Pages.Items
{
    public class IndexModel : PageModel
    {
        public ItemDetails itemDetails;

        public IndexModel(Domain.Services.IBtwTypeData btwTypeData, Domain.Services.ICatagoryData catagoryData, Domain.Services.IItemData itemData)
        {
            itemDetails = new ItemDetails(btwTypeData, catagoryData, itemData);
        }

        public void OnGet()
        {
        }
    }
}
