namespace DB
{
    public class LinksOwnerCarDepartureValidator
    {
        public static void ValidateLinkOwnerCarDeparture(LinkOwnerCarDeparture linkOwnerCarDeparture)
        {
            if (linkOwnerCarDeparture == null
                || linkOwnerCarDeparture.OwnerId < 1 || 
                linkOwnerCarDeparture.CarId.Length == 0)
                // || linkOwnerCarDeparture.DepartureId < 1)
            {
                throw new LinksOwnerCarDepartureValidatorFailException();
                // throw new LinksOwnerCarDepartureValidatorFailException($"LinkOwnerCarDeparture: {linkOwnerCarDeparture.OwnerId}, {linkOwnerCarDeparture.CarId}, {linkOwnerCarDeparture.DepartureId}\n");
            }
        }
    }
}