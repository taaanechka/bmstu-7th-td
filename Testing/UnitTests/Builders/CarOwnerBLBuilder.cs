using BL;
using UnitTests.Entities;
using UnitTests.Converters;

namespace UnitTests.Builders
{
    public class CarOwnerBLBuilder
    {
        private UnitTests.Entities.CarOwner _carOwner;

        public CarOwnerBLBuilder()
        {
            _carOwner = new UnitTests.Entities.CarOwner();
        }

        public CarOwnerBLBuilder WithName(string name)
        {
            _carOwner.Name = name;
            return this;
        }

        public CarOwnerBLBuilder WithSurname(string surname)
        {
            _carOwner.Surname = surname;
            return this;
        }

        public CarOwnerBLBuilder WithEmail(string email)
        {
            _carOwner.Email = email;
            return this;
        }

        public BL.CarOwner Build()
        {
            return CarOwnerConverter.TestToBL(_carOwner);
            // return _carOwner;
        }
    }
}