using BL;
using UnitTests.Entities;

namespace UnitTests.Converters
{
    public class DepartureConverter
    {
        public static BL.Departure TestToBL(UnitTests.Entities.Departure Departure)
        {
            return new BL.Departure(Departure.Id, Departure.UserId, Departure.DepartureDate);
        }

        public static UnitTests.Entities.Departure BLToTest(BL.Departure DepartureBL)
        {
            UnitTests.Entities.Departure departure = new UnitTests.Entities.Departure();
            departure.UserId = DepartureBL.UserId;
            departure.DepartureDate = DepartureBL.DepartureDate;

            return departure;
        }
    }
}