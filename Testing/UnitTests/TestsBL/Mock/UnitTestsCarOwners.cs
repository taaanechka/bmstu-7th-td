using System;
using System.Collections.Generic;
using Xunit;
using Moq;

using BL;
using UnitTests.ObjectMothers;

namespace UnitTests.TestsBL
{
    public class UnitTestsCarOwners
    {
        [Fact]
        public void TestGetCarOwners()
        {
            // Arrange
            var retCarOwners = new List<BL.CarOwner>() {
                        CarOwnerObjectMother.DefaultCarOwner().Build(),
                        CarOwnerObjectMother.DefaultCarOwner2().Build()
            };

            Mock<BL.ICarOwnersRepository> mockCarOwnersRep = new Mock<BL.ICarOwnersRepository>();
            mockCarOwnersRep.Setup(r => r.GetCarOwners(It.IsAny<int>(), It.IsAny<int>()))
                        .Returns(retCarOwners);

            BL.IRepositoriesFactory mockRepFactory = Mock.Of<BL.IRepositoriesFactory>(f => 
                                                        f.CreateCarOwnersRepository() == mockCarOwnersRep.Object);
            BL.Facade facade = new BL.Facade(mockRepFactory);

            // Act
            List<BL.CarOwner> CarOwners = facade.GetCarOwners();

            // Assert
            Assert.Equal(retCarOwners.Count, CarOwners.Count);
        }

        [Fact]
        public void TestGetCarById()
        {
            // Arrange
            var owner = CarOwnerObjectMother.DefaultCarOwner().Build();

            Mock<BL.ICarOwnersRepository> mockCarOwnersRep = new Mock<BL.ICarOwnersRepository>();
            mockCarOwnersRep.Setup(rep => rep.GetCarOwnerById(It.IsAny<int>())).Returns(owner);

            BL.IRepositoriesFactory mockRepFactory = Mock.Of<BL.IRepositoriesFactory>(f => 
                                                        f.CreateCarOwnersRepository() == mockCarOwnersRep.Object);
            BL.Facade facade = new BL.Facade(mockRepFactory);

            // Act
            BL.CarOwner res = facade.GetCarOwnerById(1);

            // Assert
            Assert.NotNull(res);
            mockCarOwnersRep.Verify(x => x.GetCarOwnerById(1), Times.Once);
        }

        [Fact]
        public void TestAddCarOwner()
        {
            // Arrange
            var owner = CarOwnerObjectMother.DefaultCarOwner().Build();

            Mock<BL.ICarOwnersRepository> mockCarOwnersRep = new Mock<BL.ICarOwnersRepository>();
            mockCarOwnersRep.Setup(rep => rep.AddCarOwner(It.IsAny<BL.CarOwner>())).Verifiable();

            BL.IRepositoriesFactory mockRepFactory = Mock.Of<BL.IRepositoriesFactory>(f => 
                                                        f.CreateCarOwnersRepository() == mockCarOwnersRep.Object);
            BL.Facade facade = new BL.Facade(mockRepFactory);

            // Act
            facade.AddCarOwner(owner);

            // Assert
            mockCarOwnersRep.Verify(x => x.AddCarOwner(owner));
        }

        [Fact]
        public void TestUpdateCarOwner()
        {
            // Arrange
            var owner = CarOwnerObjectMother.DefaultCarOwner().Build();

            Mock<BL.ICarOwnersRepository> mockCarOwnersRep = new Mock<BL.ICarOwnersRepository>();
            mockCarOwnersRep.Setup(rep => rep.GetCarOwnerById(It.IsAny<int>())).Returns(owner);
            mockCarOwnersRep.Setup(rep => rep.UpdateCarOwner(It.IsAny<int>(), It.IsAny<BL.CarOwner>())).Verifiable();

            BL.IRepositoriesFactory mockRepFactory = Mock.Of<BL.IRepositoriesFactory>(f => 
                                                        f.CreateCarOwnersRepository() == mockCarOwnersRep.Object);
            BL.Facade facade = new BL.Facade(mockRepFactory);

            // Act
            facade.UpdateCarOwner(1, owner);

            // Assert
            mockCarOwnersRep.Verify(x => x.GetCarOwnerById(1), Times.Once);
            mockCarOwnersRep.Verify(x => x.UpdateCarOwner(1, It.IsAny<BL.CarOwner>()), Times.Once);
        }

        [Fact]
        public void TestDeleteCarOwner()
        {
            // Arrange
            Mock<BL.ICarOwnersRepository> mockCarOwnersRep = new Mock<BL.ICarOwnersRepository>();
            mockCarOwnersRep.Setup(rep => rep.DeleteCarOwner(It.IsAny<int>())).Verifiable();

            BL.IRepositoriesFactory mockRepFactory = Mock.Of<BL.IRepositoriesFactory>(f => 
                                                        f.CreateCarOwnersRepository() == mockCarOwnersRep.Object);
            BL.Facade facade = new BL.Facade(mockRepFactory);

            // Act
            facade.DeleteCarOwner(1);

            // Assert
            mockCarOwnersRep.Verify(x => x.DeleteCarOwner(1), Times.Once);
        }
    }
}