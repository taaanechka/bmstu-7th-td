#nullable disable

namespace BL
{
    public class Color
    {
        protected Color ()
        {}
        
        public Color (int id, string name)
        {
            
            Id = id;
            Name = name;
        }

        public int Id { get; }
        public string Name { get; }
    }
}