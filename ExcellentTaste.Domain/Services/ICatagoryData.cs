using System;
using System.Collections.Generic;
using System.Text;
using ExcellentTaste.Domain.Models;

namespace ExcellentTaste.Domain.Services
{
    public interface ICatagoryData
    {
        IEnumerable<Catagory> GetAll();
        Catagory Get(int catagoryId);
    }
}
