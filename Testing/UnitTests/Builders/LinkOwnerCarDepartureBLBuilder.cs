using System;

using BL;
using UnitTests.Entities;
using UnitTests.Converters;

namespace UnitTests.Builders
{
    public class LinkOwnerCarDepartureBLBuilder
    {
        private UnitTests.Entities.LinkOwnerCarDeparture _linkOwnerCarDeparture;

        public LinkOwnerCarDepartureBLBuilder()
        {
            _linkOwnerCarDeparture = new UnitTests.Entities.LinkOwnerCarDeparture();
        }

        public LinkOwnerCarDepartureBLBuilder WithOwnerId(int ownerId)
        {
            _linkOwnerCarDeparture.OwnerId = ownerId;
            return this;
        }

        public LinkOwnerCarDepartureBLBuilder WithCarId(string carId)
        {
            _linkOwnerCarDeparture.CarId = carId;
            return this;
        }

        public LinkOwnerCarDepartureBLBuilder WithDepartureId(int departureId)
        {
            _linkOwnerCarDeparture.DepartureId = departureId;
            return this;
        }

        public BL.LinkOwnerCarDeparture Build()
        {
            return LinkOwnerCarDepartureConverter.TestToBL(_linkOwnerCarDeparture);
            // return _linkOwnerCarDeparture;
        }
    }
}