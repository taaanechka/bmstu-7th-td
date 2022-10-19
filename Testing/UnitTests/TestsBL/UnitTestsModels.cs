using System;
using System.Collections.Generic;
using Xunit;
using Moq;

using BL;
using UnitTests.ObjectMothers;

namespace UnitTests.TestsBL
{
    public class UnitTestModels
    {
        [Fact]
        public void TestGetModelById()
        {
            // Arrange
            var model = ModelObjectMother.DefaultModel().Build();

            Mock<BL.IModelsRepository> mockModelsRep = new Mock<BL.IModelsRepository>();
            mockModelsRep.Setup(rep => rep.GetModelById(It.IsAny<int>())).Returns(model);

            BL.IRepositoriesFactory mockRepFactory = Mock.Of<BL.IRepositoriesFactory>(f => 
                                                        f.CreateModelsRepository() == mockModelsRep.Object);
            BL.Facade facade = new BL.Facade(mockRepFactory);

            // Act
            BL.Model Model = facade.GetModelById(1);

            // Assert
            Assert.NotNull(Model);
            mockModelsRep.Verify(x => x.GetModelById(1), Times.Once);
        }

        [Fact]
        public void TestAddModel()
        {
            // Arrange
            var model = ModelObjectMother.DefaultModel().Build();

            Mock<BL.IModelsRepository> mockModelsRep = new Mock<BL.IModelsRepository>();
            mockModelsRep.Setup(rep => rep.AddModel(It.IsAny<BL.Model>())).Verifiable();

            BL.IRepositoriesFactory mockRepFactory = Mock.Of<BL.IRepositoriesFactory>(f => 
                                                        f.CreateModelsRepository() == mockModelsRep.Object);
            BL.Facade facade = new BL.Facade(mockRepFactory);

            // Act
            facade.AddModel(model);

            // Assert
            mockModelsRep.Verify(x => x.AddModel(model), Times.Once);
        }

        [Fact]
        public void TestUpdateModel()
        {
            // Arrange
            var model = ModelObjectMother.DefaultModel().Build();

            Mock<BL.IModelsRepository> mockModelsRep = new Mock<BL.IModelsRepository>();
            mockModelsRep.Setup(rep => rep.GetModelById(It.IsAny<int>())).Returns(model);
            mockModelsRep.Setup(rep => rep.UpdateModel(It.IsAny<int>(), It.IsAny<BL.Model>())).Verifiable();

            BL.IRepositoriesFactory mockRepFactory = Mock.Of<BL.IRepositoriesFactory>(f => 
                                                        f.CreateModelsRepository() == mockModelsRep.Object);
            BL.Facade facade = new BL.Facade(mockRepFactory);

            // Act
            facade.UpdateModel(1, model);

            // Assert
            mockModelsRep.Verify(x => x.GetModelById(1), Times.Once);
            mockModelsRep.Verify(x => x.UpdateModel(1, It.IsAny<BL.Model>()), Times.Once);
        }

        [Fact]
        public void TestDeleteModel()
        {
            // Arrange
            Mock<BL.IModelsRepository> mockModelsRep = new Mock<BL.IModelsRepository>();
            mockModelsRep.Setup(rep => rep.DeleteModel(It.IsAny<int>())).Verifiable();

            BL.IRepositoriesFactory mockRepFactory = Mock.Of<BL.IRepositoriesFactory>(f => 
                                                        f.CreateModelsRepository() == mockModelsRep.Object);
            BL.Facade facade = new BL.Facade(mockRepFactory);

            // Act
            facade.DeleteModel(1);

            // Assert
            mockModelsRep.Verify(x => x.DeleteModel(1), Times.Once);
        } 
    }
}