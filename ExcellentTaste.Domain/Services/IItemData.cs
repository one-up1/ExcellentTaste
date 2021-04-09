using System;
using System.Collections.Generic;
using System.Text;
using ExcellentTaste.Domain.Models;

namespace ExcellentTaste.Domain.Services
{
    public interface IItemData
    {
        IEnumerable<Item> GetAll();
        IEnumerable<Item> GetAllAvailable();
        Item Get(int itemId);
        void Create(Item newItem);
        void Edit(Item editedItem);
        void Delete(int itemToDeleteId);
    }
}
