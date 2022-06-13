using EventPlaning.Data.Repository;
using EventPlaning.Models;
using EventPlaning.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace EventPlaning.Services.Implementations
{
    public class UserEventService : IUserEventService
    {
        private IRepository<UserEvent> _userEvent;
        public UserEventService(IRepository<UserEvent> userEvent)
        {
            _userEvent = userEvent ?? throw new ArgumentNullException(nameof(userEvent));
        }
        public void AddItem(UserEvent newUserEvent, string userId)
        {
            newUserEvent.Id = Guid.NewGuid();
            newUserEvent.Owner = Guid.Parse(userId);

            _userEvent.AddItem(newUserEvent);
            Save();
        }

        public UserEvent GetItemById(Guid Id)
        {
            return _userEvent.GetItemById(Id);
        }

        public IEnumerable<UserEvent> GetItems()
        {
            return _userEvent.GetItems();
        }
        public void Save()
        {
            _userEvent.Save();
        }
    }
}
