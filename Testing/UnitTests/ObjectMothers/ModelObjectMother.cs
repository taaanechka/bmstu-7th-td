using UnitTests.Builders;
using BL;

namespace UnitTests.ObjectMothers
{
    public class ModelObjectMother
    {
        public static ModelBLBuilder DefaultModel() 
        {
            return new ModelBLBuilder()
                        .WithBrandId(1)
                        .WithName("Name1");
        }

        public static ModelBLBuilder DefaultModel2() 
        {
            return new ModelBLBuilder()
                        .WithBrandId(2)
                        .WithName("Name2");
        }

        public static ModelBLBuilder DefaultModel3() 
        {
            return new ModelBLBuilder()
                        .WithBrandId(3)
                        .WithName("Name3");
        }

        public static ModelBLBuilder DefaultModel4() 
        {
            return new ModelBLBuilder()
                        .WithBrandId(4)
                        .WithName("Name4");
        }

        public static ModelBLBuilder UpdDefaultModel() 
        {
            return new ModelBLBuilder()
                        .WithBrandId(1)
                        .WithName("NameNew");
        }

        public static ModelBLBuilder WithoutBrandIdModel() 
        {
            return new ModelBLBuilder()
                        .WithName("Name3");
        }

        public static ModelBLBuilder WithoutNameModel() 
        {
            return new ModelBLBuilder()
                        .WithBrandId(4);
        }
    }
}