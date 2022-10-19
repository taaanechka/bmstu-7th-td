using BL;
using UnitTests.Entities;

namespace UnitTests.Converters
{
    public class LinkOwnerCarDepartureConverter
    {
        public static BL.LinkOwnerCarDeparture TestToBL(UnitTests.Entities.LinkOwnerCarDeparture LinkOwnerCarDeparture)
        {
            return new BL.LinkOwnerCarDeparture(LinkOwnerCarDeparture.Id, 
                                            LinkOwnerCarDeparture.OwnerId, 
                                            LinkOwnerCarDeparture.CarId, 
                                            LinkOwnerCarDeparture.DepartureId);
        }

        public static UnitTests.Entities.LinkOwnerCarDeparture BLToTest(BL.LinkOwnerCarDeparture LinkOwnerCarDepartureBL)
        {
            UnitTests.Entities.LinkOwnerCarDeparture LinkOwnerCarDeparture= new UnitTests.Entities.LinkOwnerCarDeparture();
            LinkOwnerCarDeparture.OwnerId = LinkOwnerCarDepartureBL.OwnerId;
            LinkOwnerCarDeparture.CarId = LinkOwnerCarDepartureBL.CarId;
            LinkOwnerCarDeparture.DepartureId = LinkOwnerCarDepartureBL.DepartureId;

            return LinkOwnerCarDeparture;
        }
    }
}