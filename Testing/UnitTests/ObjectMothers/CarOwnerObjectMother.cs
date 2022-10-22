using UnitTests.Builders;
using BL;

namespace UnitTests.ObjectMothers
{
    public class CarOwnerObjectMother
    {
        public static CarOwnerBLBuilder DefaultCarOwner() 
        {
            return new CarOwnerBLBuilder()
                        .WithName("NameDefault")
                        .WithSurname("SurnameDefault")
                        .WithEmail("EmailDefault");
        }

        public static CarOwnerBLBuilder DefaultCarOwner2() 
        {
            return new CarOwnerBLBuilder()
                        .WithName("NameDefault2")
                        .WithSurname("SurnameDefault2")
                        .WithEmail("EmailDefault2");
        }

        public static CarOwnerBLBuilder DefaultCarOwner3() 
        {
            return new CarOwnerBLBuilder()
                        .WithName("NameDefault3")
                        .WithSurname("SurnameDefault3")
                        .WithEmail("EmailDefault3");
        }

        public static CarOwnerBLBuilder DefaultCarOwner4() 
        {
            return new CarOwnerBLBuilder()
                        .WithName("NameDefault4")
                        .WithSurname("SurnameDefault4")
                        .WithEmail("EmailDefault4");
        }

        public static CarOwnerBLBuilder UpdCarOwner() 
        {
            return new CarOwnerBLBuilder()
                        .WithName("NameDefault2")
                        .WithSurname("SurnameUpd")
                        .WithEmail("EmailDefault2");
        }

        public static CarOwnerBLBuilder WithoutNameCarOwner() 
        {
            return new CarOwnerBLBuilder()
                        .WithSurname("SurnameAnalyst")
                        .WithEmail("EmailDefault");
        }

        public static CarOwnerBLBuilder WithoutEmailCarOwner() 
        {
            return new CarOwnerBLBuilder()
                        .WithName("NameAdmin")
                        .WithSurname("SurnameAdmin");;
        }
    }
}