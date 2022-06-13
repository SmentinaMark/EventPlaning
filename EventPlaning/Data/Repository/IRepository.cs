using System;
using System.Collections.Generic;

namespace EventPlaning.Data.Repository
{
    public interface IRepository<T> : IDisposable
    {
        IEnumerable<T> GetItems();
        T GetItemById(Guid itemId);
        void AddItem(T item);
        void Save();
    }
}
