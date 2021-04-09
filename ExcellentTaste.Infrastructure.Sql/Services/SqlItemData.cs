using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExcellentTaste.Domain.Models;
using ExcellentTaste.Domain.Services;
using ExcellentTaste.Infrastructure.Sql.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace ExcellentTaste.Infrastructure.Sql.Services
{
    public class SqlItemData : IItemData
    {
        private const bool availabilityOfDeleted = false;
        private const bool availabilityOfAvailable = true;

        private readonly ItemDbContext db;

        public SqlItemData(ItemDbContext db)
        {
            this.db = db;
        }

        public void Create(Item newItem)
        {
            var entry = db.Items.Add(newItem);
            entry.State = EntityState.Added;
            db.SaveChanges();
        }

        public void Delete(int itemToDeleteId)
        {
            Item toDelete = Get(itemToDeleteId);
            toDelete.Available = availabilityOfDeleted;
            Edit(toDelete);
        }

        public void Edit(Item editedItem)
        {
            var entry = db.Attach(editedItem);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }

        public Item Get(int itemId)
        {
            return db.Items.Find(itemId);
        }

        public IEnumerable<Item> GetAll()
        {
            return db.Items;
        }

        public IEnumerable<Item> GetAllAvailable()
        {
            return db.Items.Where(i => i.Available == availabilityOfAvailable);
        }
    }
}
