using System;

using UnitTests.Builders;
using BL;

namespace UnitTests.ObjectMothers
{
    public class LinkOwnerCarDepartureObjectMother
    {
        public static LinkOwnerCarDepartureBLBuilder DefaultLinkOwnerCarDeparture(string carNumber = "Number1") 
        {
            return new LinkOwnerCarDepartureBLBuilder()
                        .WithOwnerId(1)
                        .WithCarId(carNumber)
                        .WithDepartureId(1);
        }

        public static LinkOwnerCarDepartureBLBuilder DefaultLinkOwnerCarDeparture2() 
        {
            return new LinkOwnerCarDepartureBLBuilder()
                        .WithOwnerId(1)
                        .WithCarId("Number2")
                        .WithDepartureId(2);
        }

        public static LinkOwnerCarDepartureBLBuilder DefaultLinkOwnerCarDeparture3() 
        {
            return new LinkOwnerCarDepartureBLBuilder()
                        .WithOwnerId(1)
                        .WithCarId("Number3")
                        .WithDepartureId(3);
        }

        public static LinkOwnerCarDepartureBLBuilder DefaultLinkOwnerCarDeparture4() 
        {
            return new LinkOwnerCarDepartureBLBuilder()
                        .WithOwnerId(1)
                        .WithCarId("Number4")
                        .WithDepartureId(4);
        }

        public static LinkOwnerCarDepartureBLBuilder WithoutOwnerIdLinkOwnerCarDeparture() 
        {
            return new LinkOwnerCarDepartureBLBuilder()
                        .WithCarId("Number5")
                        .WithDepartureId(5);
        }

        public static LinkOwnerCarDepartureBLBuilder WithoutCarIdIdLinkOwnerCarDeparture() 
        {
            return new LinkOwnerCarDepartureBLBuilder()
                        .WithOwnerId(1)
                        .WithDepartureId(6);
        }
    }
}