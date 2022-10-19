using BL;
using UnitTests.Entities;

namespace UnitTests.Converters
{
    public class CarOwnerConverter
    {
        public static BL.CarOwner TestToBL(UnitTests.Entities.CarOwner CarOwner)
        {
            return new BL.CarOwner(CarOwner.Id, CarOwner.Name, CarOwner.Surname, CarOwner.Email);
        }

        public static UnitTests.Entities.CarOwner BLToTest(BL.CarOwner CarOwnerBL)
        {
            UnitTests.Entities.CarOwner carOwner = new UnitTests.Entities.CarOwner();
            carOwner.Name = CarOwnerBL.Name;
            carOwner.Surname = CarOwnerBL.Surname;
            carOwner.Email = CarOwnerBL.Email;

            return carOwner;
        }
    }
}