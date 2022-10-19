using System;

using UnitTests.Builders;
using BL;

namespace UnitTests.ObjectMothers
{
    public class DepartureObjectMother
    {
        public static DepartureBLBuilder DefaultDeparture() 
        {
            DateTime date = DateTime.ParseExact("2022-04-10", "yyyy-MM-dd",
                                        System.Globalization.CultureInfo.InvariantCulture);
            date = DateTime.SpecifyKind(date, DateTimeKind.Utc);

            return new DepartureBLBuilder()
                        .WithUserId(1)
                        .WithDepartureDate(date);
        }

        public static DepartureBLBuilder DefaultDeparture2() 
        {
            DateTime date = DateTime.ParseExact("2022-04-10", "yyyy-MM-dd",
                                        System.Globalization.CultureInfo.InvariantCulture);
            date = DateTime.SpecifyKind(date, DateTimeKind.Utc);

            return new DepartureBLBuilder()
                        .WithUserId(2)
                        .WithDepartureDate(date);
        }

        public static DepartureBLBuilder WithoutDateDeparture() 
        {
            DateTime date = DateTime.ParseExact("2022-04-10", "yyyy-MM-dd",
                                        System.Globalization.CultureInfo.InvariantCulture);
            date = DateTime.SpecifyKind(date, DateTimeKind.Utc);

            return new DepartureBLBuilder()
                        .WithUserId(1);
        }

        public static DepartureBLBuilder WithoutUserIdDeparture() 
        {
            DateTime date = DateTime.ParseExact("2022-04-10", "yyyy-MM-dd",
                                        System.Globalization.CultureInfo.InvariantCulture);
            date = DateTime.SpecifyKind(date, DateTimeKind.Utc);

            return new DepartureBLBuilder()
                        .WithDepartureDate(date);
        }
    }
}