using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExcellentTaste.Domain;
using ExcellentTaste.Domain.Services;
using ExcellentTaste.Infrastructure.Sql.DbContexts;

namespace ExcellentTaste.Infrastructure.Sql.Services
{
    class SqlItemData : IItemData
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
            var entry = db.Entry(newItem);
            entry.State = System.Data.Entity.EntityState.Added;
            db.SaveChanges();
        }

        public void Delete(Item itemToDelete)
        {
            itemToDelete.Available = availabilityOfDeleted;
            var entry = db.Entry(itemToDelete);
            entry.State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public void Edit(Item editedItem)
        {
            var entry = db.Entry(editedItem);
            entry.State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public Item Get(int itemId)
        {
            return db.Items.FirstOrDefault(i => i.Id == itemId);
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
