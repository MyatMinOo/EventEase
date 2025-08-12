using EventEase.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace EventEase.Services
{
    public class EventService
    {
        private readonly ConcurrentDictionary<int, Event> _events = new();
        private readonly ConcurrentDictionary<int, Registration> _registrations = new();
        private int _nextEventId = 1;
        private int _nextRegistrationId = 1;

        public EventService()
        {
            // Initialize with sample data
            AddEvent(new Event
            {
                Name = "Tech Conference 2023",
                Date = DateTime.Now.AddDays(30),
                Location = "Convention Center",
                Description = "Annual technology conference",
                AvailableSeats = 200
            });

            AddEvent(new Event
            {
                Name = "Music Festival",
                Date = DateTime.Now.AddDays(45),
                Location = "Central Park",
                Description = "Summer music festival",
                AvailableSeats = 5000
            });
        }

        public IEnumerable<Event> GetEvents() => _events.Values.OrderBy(e => e.Date);

        public Event? GetEvent(int id) => _events.TryGetValue(id, out var @event) ? @event : null;

        public void AddEvent(Event @event)
        {
            @event.Id = _nextEventId++;
            _events[@event.Id] = @event;
        }

        public void RegisterForEvent(Registration registration)
        {
            registration.Id = _nextRegistrationId++;
            _registrations[registration.Id] = registration;

            if (_events.TryGetValue(registration.EventId, out var @event))
            {
                @event.AvailableSeats--;
            }
        }

        public IEnumerable<Registration> GetRegistrations() => _registrations.Values;
    }
}