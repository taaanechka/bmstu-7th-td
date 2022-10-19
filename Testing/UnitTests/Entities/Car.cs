using BL;

namespace UnitTests.Entities
{
    public class Car: BL.Car
    {
        new public string? Id { get; set; }
        new public int ModelId { get; set; }
        new public int EquipmentId { get; set; }
        new public int ColorId { get; set; }
        new public int ComingId { get; set; }
    }
}