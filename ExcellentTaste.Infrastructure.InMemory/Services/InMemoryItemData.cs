﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExcellentTaste.Domain;
using ExcellentTaste.Domain.Services;

namespace ExcellentTaste.Infrastructure.InMemory.Services
{
    public class InMemoryItemData : IItemData
    {
        private const bool availableOfDeleted = false;
        private const bool availableOfAvailable = true;

        private List<Item> items;

        public InMemoryItemData()
        {
            items = new List<Item>()
            {
                new Item(){ Id = 1, Description = "goop", Price = 5.50F, BtwTypeId = 1, CatagoryId = 1, Available = true },
                new Item(){ Id = 2, Description = "goop juice", Price = 1.50F, BtwTypeId = 2, CatagoryId = 2, Available = true},
                new Item(){ Id = 3, Description = "old goop", Price = 5F, BtwTypeId = 1, CatagoryId = 1, Available = false}
            };
        }

        public void Create(Item newItem)
        {
            items.Add(newItem);
        }

        public void Delete(Item itemToDelete)
        {
            for(int i = 0; i < items.Count; i++)
            {
                if(items[i].Id == itemToDelete.Id)
                {
                    items[i].Available = availableOfDeleted;
                    return;
                }
            }
        }

        public void Edit(Item editedItem)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Id == editedItem.Id)
                {
                    items[i] = editedItem;
                    return;
                }
            }
        }

        public Item Get(int itemId)
        {
            return items.FirstOrDefault(i => i.Id == itemId);
        }

        public IEnumerable<Item> GetAll()
        {
            return items;
        }

        public IEnumerable<Item> GetAllAvailable()
        {
            return items.Where(i => i.Available == availableOfAvailable);
        }
    }
}