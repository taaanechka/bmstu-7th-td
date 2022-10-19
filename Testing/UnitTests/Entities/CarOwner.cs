using BL;

namespace UnitTests.Entities
{
    public class CarOwner: BL.CarOwner
    {
        new public int Id { get; set; }
        new public string? Name { get; set; }
        new public string? Surname { get; set; }
        new public string? Email { get; set; }
    }
}