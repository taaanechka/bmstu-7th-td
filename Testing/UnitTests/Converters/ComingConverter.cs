using BL;
using UnitTests.Entities;

namespace UnitTests.Converters
{
    public class ComingConverter
    {
        public static BL.Coming TestToBL(UnitTests.Entities.Coming Coming)
        {
            return new BL.Coming(Coming.Id, Coming.UserId, Coming.ComingDate);
        }

        public static UnitTests.Entities.Coming BLToTest(BL.Coming ComingBL)
        {
            UnitTests.Entities.Coming coming = new UnitTests.Entities.Coming {
                UserId = ComingBL.UserId,
                ComingDate = ComingBL.ComingDate};

            return coming;
        }
    }
}