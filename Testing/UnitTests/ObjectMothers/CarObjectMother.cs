using UnitTests.Builders;
using BL;

namespace UnitTests.ObjectMothers
{
    public class CarObjectMother
    {
        public static CarBLBuilder DefaultCar(int comId = 1) 
        {
            return new CarBLBuilder()
                        .WithId("Number1")
                        .WithModelId(1)
                        .WithEquipmentId(1)
                        .WithColorId(1)
                        .WithComingId(comId);
        }

        public static CarBLBuilder DefaultCar2() 
        {
            return new CarBLBuilder()
                        .WithId("Number2")
                        .WithModelId(1)
                        .WithEquipmentId(1)
                        .WithColorId(2)
                        .WithComingId(2);
        }

        public static CarBLBuilder DefaultCar3() 
        {
            return new CarBLBuilder()
                        .WithId("Number3")
                        .WithModelId(3)
                        .WithEquipmentId(2)
                        .WithColorId(2)
                        .WithComingId(3);
        }

        public static CarBLBuilder DefaultCar4() 
        {
            return new CarBLBuilder()
                        .WithId("Number4")
                        .WithModelId(2)
                        .WithEquipmentId(3)
                        .WithColorId(3)
                        .WithComingId(4);
        }

        public static CarBLBuilder DefaultCar5() 
        {
            return new CarBLBuilder()
                        .WithId("Number5")
                        .WithModelId(3)
                        .WithEquipmentId(4)
                        .WithColorId(4)
                        .WithComingId(5);
        }

        public static CarBLBuilder UpdDefaultCar() 
        {
            return new CarBLBuilder()
                        .WithId("Number1")
                        .WithModelId(1)
                        .WithEquipmentId(1)
                        .WithColorId(3)
                        .WithComingId(1);
        }

        public static CarBLBuilder WithoutNumberCar() 
        {
            return new CarBLBuilder()
                        .WithModelId(1)
                        .WithEquipmentId(1)
                        .WithColorId(1)
                        .WithComingId(5);
        }

        public static CarBLBuilder WithoutColorCar() 
        {
            return new CarBLBuilder()
                        .WithId("Number6")
                        .WithModelId(4)
                        .WithEquipmentId(3)
                        .WithComingId(7);
        }

        public static CarBLBuilder DefaultCarWithoutComingId() 
        {
            return new CarBLBuilder()
                        .WithId("Number1")
                        .WithModelId(1)
                        .WithEquipmentId(1)
                        .WithColorId(1);
        }
    }
}