using System;

using BL;
using UnitTests.Entities;
using UnitTests.Converters;

namespace UnitTests.Builders
{
    public class DepartureBLBuilder
    {
        private UnitTests.Entities.Departure _departure;

        public DepartureBLBuilder()
        {
            _departure = new UnitTests.Entities.Departure();
        }

        public DepartureBLBuilder WithUserId(int userId)
        {
            _departure.UserId = userId;
            return this;
        }

        public DepartureBLBuilder WithDepartureDate(DateTime date)
        {
            _departure.DepartureDate = date;
            return this;
        }

        public BL.Departure Build()
        {
            return DepartureConverter.TestToBL(_departure);
            // return _departure;
        }
    }
}