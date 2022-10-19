using BL;
using UnitTests.Entities;

namespace UnitTests.Converters
{
    public class ModelConverter
    {
        public static BL.Model TestToBL(UnitTests.Entities.Model Model)
        {
            return new BL.Model(Model.Id, Model.BrandId, Model.Name);
        }

        public static UnitTests.Entities.Model BLToTest(BL.Model ModelBL)
        {
            UnitTests.Entities.Model model = new UnitTests.Entities.Model();
            model.BrandId = ModelBL.BrandId;
            model.Name = ModelBL.Name;

            return model;
        }
    }
}