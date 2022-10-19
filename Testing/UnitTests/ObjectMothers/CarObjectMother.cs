using UnitTests.Builders;
using BL;

namespace UnitTests.ObjectMothers
{
    public class CarObjectMother
    {
        public static CarBLBuilder DefaultCar() 
        {
            return new CarBLBuilder()
                        .WithId("Number1")
                        .WithModelId(1)
                        .WithEquipmentId(1)
                        .WithColorId(5)
                        .WithComingId(1);
        }

        public static CarBLBuilder UpdDefaultCar() 
        {
            return new CarBLBuilder()
                        .WithId("Number1")
                        .WithModelId(1)
                        .WithEquipmentId(1)
                        .WithColorId(6)
                        .WithComingId(1);
        }

        public static CarBLBuilder DefaultCar2() 
        {
            return new CarBLBuilder()
                        .WithId("Number2")
                        .WithModelId(1)
                        .WithEquipmentId(1)
                        .WithColorId(5)
                        .WithComingId(1);
        }

        public static CarBLBuilder WithoutNumberCar() 
        {
            return new CarBLBuilder()
                        .WithModelId(3)
                        .WithEquipmentId(2)
                        .WithColorId(4)
                        .WithComingId(2);
        }

        public static CarBLBuilder WithoutColorCar() 
        {
            return new CarBLBuilder()
                        .WithId("Number3")
                        .WithModelId(6)
                        .WithEquipmentId(8)
                        .WithComingId(3);
        }
    }
}