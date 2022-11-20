#nullable disable

namespace BL
{
    public class Brand
    {
        protected Brand ()
        {}
        
        public Brand (int id, string name, string mcountry, string wheel)
        {
            Id = id;
            Name = name;
            ManufactCountry = mcountry;
            Wheel = wheel;
        }

        public int Id { get; }
        public string Name { get; }
        public string ManufactCountry { get; }
        public string Wheel { get; }
    }
}
