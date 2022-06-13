using EventPlaning.Data.Contexts;
using EventPlaning.Models.UserEvents;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EventPlaning.Data.Repository
{
    public class ParticipantRepository : IRepository<EventParticipant>
    {
        private ApplicationDbContext _context;
        public ParticipantRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<EventParticipant> GetItems()
        {
            return _context.EventPartisipiants.ToList();
        }

        public EventParticipant GetItemById(Guid itemId)
        {
            return _context.EventPartisipiants.Find(itemId);
        }

        public void AddItem(EventParticipant item)
        {
            _context.EventPartisipiants.Add(item);
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
