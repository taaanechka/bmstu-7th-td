using System;

using BL;

namespace UnitTests.Entities
{
    public class Coming: BL.Coming
    {
        new public int Id { get; set; }
        new public int UserId { get; set; }
        new public DateTime ComingDate { get; set; } = DateTime.UtcNow;
    }
}