using System;
using System.Collections.Generic;

namespace Jibble.Domain.Entities
{
    public class Person
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
    }

    public class PersonDetails : Person
    {
        public List<Person> Friends { get; set; }
        public List<Trip> Trips { get; set; }
    }

    public class Trip
    {
        public int TripId { get; set; }
        public string ShareId { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public int Budget { get; set; }
        public DateTimeOffset StartsAt { get; set; }
        public DateTimeOffset EndsAt { get; set; }
        public List<string> Tags { get; set; }
    }
}