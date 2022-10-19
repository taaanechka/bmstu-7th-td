using System;

using BL;

namespace UnitTests.Entities
{
    public class Departure: BL.Departure
    {
        new public int Id { get; set; }
        new public int UserId { get; set; }
        new public DateTime DepartureDate { get; set; } = DateTime.UtcNow;
    }
}