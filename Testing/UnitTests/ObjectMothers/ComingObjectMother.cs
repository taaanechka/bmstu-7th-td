using System;

using UnitTests.Builders;
using BL;

namespace UnitTests.ObjectMothers
{
    public class ComingObjectMother
    {
        public static ComingBLBuilder DefaultComing() 
        {
            DateTime date = DateTime.ParseExact("2022-04-10", "yyyy-MM-dd",
                                        System.Globalization.CultureInfo.InvariantCulture);
            date = DateTime.SpecifyKind(date, DateTimeKind.Utc);

            return new ComingBLBuilder()
                        .WithUserId(1)
                        .WithComingDate(date);
        }

        public static ComingBLBuilder DefaultComing2() 
        {
            DateTime date = DateTime.ParseExact("2022-04-10", "yyyy-MM-dd",
                                        System.Globalization.CultureInfo.InvariantCulture);
            date = DateTime.SpecifyKind(date, DateTimeKind.Utc);

            return new ComingBLBuilder()
                        .WithUserId(2)
                        .WithComingDate(date);
        }

        public static ComingBLBuilder WithoutDateComing() 
        {
            DateTime date = DateTime.ParseExact("2022-04-10", "yyyy-MM-dd",
                                        System.Globalization.CultureInfo.InvariantCulture);
            date = DateTime.SpecifyKind(date, DateTimeKind.Utc);

            return new ComingBLBuilder()
                        .WithUserId(1);
        }

        public static ComingBLBuilder WithoutUserIdComing() 
        {
            DateTime date = DateTime.ParseExact("2022-04-10", "yyyy-MM-dd",
                                        System.Globalization.CultureInfo.InvariantCulture);
            date = DateTime.SpecifyKind(date, DateTimeKind.Utc);

            return new ComingBLBuilder()
                        .WithComingDate(date);
        }
    }
}