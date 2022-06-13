using System;

namespace EventPlaning.Models.UserEvents
{
    public class EventParticipant
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }

        public Guid UserEventId { get; set; }
        public UserEvent? UserEvent { get; set; }
    }
}
