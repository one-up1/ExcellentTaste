using System;
using System.Collections.Generic;
using System.Text;

namespace ExcellentTaste.Domain.Services
{
    interface IItemData
    {
        IEnumerable<Item> GetAll();
        Item Get(int itemId);
        void Create(Item newItem);
        void Edit(Item editedItem);
        void Delete(Item itemToDelete)
    }
}
