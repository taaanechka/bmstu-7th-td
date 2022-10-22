namespace DB
{
    public class CarsValidator
    {
        public static void ValidateCar(Car car)
        {
            if (car == null ||
                car.Id.Length == 0 ||
                car.ModelId < 1 || 
                car.EquipmentId < 1 ||
                car.ColorId < 1)
            {
                throw new CarsValidatorFailException();
            }
        }
    }
}