using BL;
using UnitTests.Entities;

namespace UnitTests.Converters
{
    public class CarConverter
    {
        public static BL.Car TestToBL(UnitTests.Entities.Car Car)
        {
            return new BL.Car(Car.Id, Car.ModelId, Car.EquipmentId, Car.ColorId, Car.ComingId);
        }

        public static UnitTests.Entities.Car BLToTest(BL.Car CarBL)
        {
            UnitTests.Entities.Car car = new UnitTests.Entities.Car();
            car.Id = CarBL.Id;
            car.ModelId = CarBL.ModelId;
            car.EquipmentId = CarBL.EquipmentId;
            car.ColorId = CarBL.ColorId;
            car.ComingId = CarBL.ComingId;

            return car;
        }
    }
}