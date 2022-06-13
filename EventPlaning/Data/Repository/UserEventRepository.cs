using EventPlaning.Data.Contexts;
using EventPlaning.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EventPlaning.Data.Repository
{
    public class UserEventRepository : IRepository<UserEvent>
    {
        private ApplicationDbContext _context;
        public UserEventRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<UserEvent> GetItems()
        {
            return _context.UserEvents.ToList();
        }

        public UserEvent GetItemById(Guid itemId)
        {
            return _context.UserEvents.Find(itemId);
        }

        public void AddItem(UserEvent item)
        {
            _context.UserEvents.Add(item);
        }
        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}