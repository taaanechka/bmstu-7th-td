using System;

using UnitTests.Builders;
using BL;

namespace UnitTests.ObjectMothers
{
    public class ComingObjectMother
    {
        public static ComingBLBuilder DefaultComing(string strDate = "2022-04-10") 
        {
            DateTime date = DateTime.ParseExact(strDate, "yyyy-MM-dd",
                                        System.Globalization.CultureInfo.InvariantCulture);
            date = DateTime.SpecifyKind(date, DateTimeKind.Utc);

            return new ComingBLBuilder()
                        .WithUserId(1)
                        .WithComingDate(date);
        }

        public static ComingBLBuilder DefaultComingWithId(string strDate = "2022-04-10") 
        {
            DateTime date = DateTime.ParseExact(strDate, "yyyy-MM-dd",
                                        System.Globalization.CultureInfo.InvariantCulture);
            date = DateTime.SpecifyKind(date, DateTimeKind.Utc);

            return new ComingBLBuilder()
                        .WithId(1150)
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

        public static ComingBLBuilder DefaultComing3() 
        {
            DateTime date = DateTime.ParseExact("2022-05-10", "yyyy-MM-dd",
                                        System.Globalization.CultureInfo.InvariantCulture);
            date = DateTime.SpecifyKind(date, DateTimeKind.Utc);

            return new ComingBLBuilder()
                        .WithUserId(3)
                        .WithComingDate(date);
        }

        public static ComingBLBuilder DefaultComing4() 
        {
            DateTime date = DateTime.ParseExact("2022-05-15", "yyyy-MM-dd",
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