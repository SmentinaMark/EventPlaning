using EventPlaning.Data.Repository;
using EventPlaning.Models;
using EventPlaning.Models.UserEvents;
using EventPlaning.Services.Interfaces;
using System;

namespace EventPlaning.Services.Implementations
{
    public class ParticipantService : IParticipantService
    {
        private IRepository<EventParticipant> _participant;
        public ParticipantService(IRepository<EventParticipant> participant)
        {
            _participant = participant ?? throw new ArgumentNullException(nameof(participant));
        }

        public void GoToEvent(Guid eventId, UserEvent userEvent, string userId)
        {
            EventParticipant newParticipant = new EventParticipant { Id = Guid.NewGuid(), UserEvent = userEvent, UserEventId = userEvent.Id, UserId = Guid.Parse(userId) };
            _participant.AddItem(newParticipant);
            _participant.Save();
        }
    }
}
