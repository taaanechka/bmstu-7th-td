using BL;

namespace UnitTests.Entities
{
    public class User: BL.User
    {
        new public int Id { get; set; } = 1;
        new public string? Name { get; set; }
        new public string? Surname { get; set; }
        new public string? Login { get; set; }
        new public string? Password { get; set; }
        new public Permissions UserType { get; set; }
    }
}