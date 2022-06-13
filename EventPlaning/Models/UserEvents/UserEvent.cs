using EventPlaning.Models.UserEvents;
using System;
using System.Collections.Generic;

namespace EventPlaning.Models
{
    public class UserEvent
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public Guid Owner { get; set; }
        public List<EventParticipant> Participants { get; set; }
    }
}
