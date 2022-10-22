using BL;
using UnitTests.Entities;
using UnitTests.Converters;

namespace UnitTests.Builders
{
    public class ModelBLBuilder
    {
        private UnitTests.Entities.Model _model;

        public ModelBLBuilder()
        {
            _model = new UnitTests.Entities.Model();
        }

        public ModelBLBuilder WithBrandId(int brandId)
        {
            _model.BrandId = brandId;
            return this;
        }

        public ModelBLBuilder WithName(string name)
        {
            _model.Name = name;
            return this;
        }

        public BL.Model Build()
        {
            return ModelConverter.TestToBL(_model);
            // return _model;
        }
    }
}