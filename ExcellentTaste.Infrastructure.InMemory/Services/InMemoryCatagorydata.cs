using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExcellentTaste.Domain;
using ExcellentTaste.Domain.Services;

namespace ExcellentTaste.Infrastructure.InMemory.Services
{
    public class InMemoryCatagorydata : ICatagoryData
    {
        private List<Catagory> catagories;

        public InMemoryCatagorydata()
        {
            catagories = new List<Catagory>()
            {
                new Catagory(){ Id = 1, Name = "goop"},
                new Catagory(){ Id = 2, Name = "juice"}
            };
        }

        public Catagory Get(int catagoryId)
        {
            return catagories.FirstOrDefault(c => c.Id == catagoryId);
        }

        public IEnumerable<Catagory> GetAll()
        {
            return catagories;
        }
    }
}
