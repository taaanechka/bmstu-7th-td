using BL;

namespace UnitTests.Entities
{
    public class LinkOwnerCarDeparture: BL.LinkOwnerCarDeparture
    {
        new public int Id { get; set; }
        new public int OwnerId { get; set; }
        new public string? CarId { get; set; }
        new public int DepartureId { get; set; }
    }
}