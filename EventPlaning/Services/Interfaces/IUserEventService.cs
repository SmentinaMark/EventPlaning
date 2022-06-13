using EventPlaning.Models;
using System;
using System.Collections.Generic;

namespace EventPlaning.Services.Interfaces
{
    public interface IUserEventService
    {
        IEnumerable<UserEvent> GetItems();
        UserEvent GetItemById(Guid Id);
        void AddItem(UserEvent newUserEvent, string userId);
        void Save();
    }
}
