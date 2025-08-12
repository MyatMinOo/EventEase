using System;

namespace EventEase.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string Location { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int AvailableSeats { get; set; }
        public string ImageUrl { get; set; } = "/images/event-placeholder.jpg";
    }

    public class Registration
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public string AttendeeName { get; set; } = string.Empty;
        public string AttendeeEmail { get; set; } = string.Empty;
        public DateTime RegistrationDate { get; set; } = DateTime.Now;
    }
}