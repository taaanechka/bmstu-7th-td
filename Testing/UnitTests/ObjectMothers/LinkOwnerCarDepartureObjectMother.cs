using System;

using UnitTests.Builders;
using BL;

namespace UnitTests.ObjectMothers
{
    public class LinkOwnerCarDepartureObjectMother
    {
        public static LinkOwnerCarDepartureBLBuilder DefaultLinkOwnerCarDeparture() 
        {
            return new LinkOwnerCarDepartureBLBuilder()
                        .WithOwnerId(1)
                        .WithCarId("Number1")
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
                        .WithCarId("Number2")
                        .WithDepartureId(2);
        }

        public static LinkOwnerCarDepartureBLBuilder WithoutCarIdIdLinkOwnerCarDeparture() 
        {
            return new LinkOwnerCarDepartureBLBuilder()
                        .WithOwnerId(1)
                        .WithDepartureId(2);
        }
    }
}