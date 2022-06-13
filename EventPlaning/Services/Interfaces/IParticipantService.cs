using EventPlaning.Models;
using System;

namespace EventPlaning.Services.Interfaces
{
    public interface IParticipantService
    {
        void GoToEvent(Guid eventId, UserEvent userEvent, string userId);
    }
}
