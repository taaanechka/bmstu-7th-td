using BL;
using UnitTests.Entities;
using UnitTests.Converters;

namespace UnitTests.Builders
{
    public class CarBLBuilder
    {
        private UnitTests.Entities.Car _car;

        public CarBLBuilder()
        {
            _car = new UnitTests.Entities.Car();
        }

        public CarBLBuilder WithId(string id)
        {
            _car.Id = id;
            return this;
        }

        public CarBLBuilder WithModelId(int modelId)
        {
            _car.ModelId = modelId;
            return this;
        }

        public CarBLBuilder WithEquipmentId(int equipmentId)
        {
            _car.EquipmentId = equipmentId;
            return this;
        }

        public CarBLBuilder WithColorId(int colorId)
        {
            _car.ColorId = colorId;
            return this;
        }

        public CarBLBuilder WithComingId(int comingId)
        {
            _car.ComingId = comingId;
            return this;
        }

        public BL.Car Build()
        {
            return CarConverter.TestToBL(_car);
            // return _car;
        }
    }
}