using BL;

namespace UnitTests.Entities
{
    public class Model: BL.Model
    {
        new public int Id { get; set; }
        new public int BrandId { get; set; }
        new public string? Name { get; set; }
    }
}