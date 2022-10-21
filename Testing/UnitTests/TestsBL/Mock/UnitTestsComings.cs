using System;
using System.Collections.Generic;
using Xunit;
using Moq;

using BL;
using UnitTests.ObjectMothers;

namespace UnitTests.TestsBL
{
    public class UnitTestComings
    {
        [Fact]
        public void TestGetComings()
        {
            // Arrange
            var retComings = new List<BL.Coming>() {
                        ComingObjectMother.DefaultComing().Build(),
                        ComingObjectMother.DefaultComing2().Build()
            };

            Mock<BL.IComingsRepository> mockComingsRep = new Mock<BL.IComingsRepository>();
            mockComingsRep.Setup(r => r.GetComings(It.IsAny<int>(), It.IsAny<int>()))
                        .Returns(retComings);
            
            BL.IRepositoriesFactory mockRepFactory = Mock.Of<BL.IRepositoriesFactory>(f => 
                                                        f.CreateComingsRepository() == mockComingsRep.Object);
            BL.Facade facade = new BL.Facade(mockRepFactory);

            // Act
            List<BL.Coming> Comings = facade.GetComings();

            // Assert
            Assert.Equal(retComings.Count, Comings.Count);
        }

        [Fact]
        public void TestGetComingById()
        {
            // Arrange
            var coming = ComingObjectMother.DefaultComing().Build();

            Mock<BL.IComingsRepository> mockComingsRep = new Mock<BL.IComingsRepository>();
            mockComingsRep.Setup(rep => rep.GetComingById(It.IsAny<int>())).Returns(coming);

            BL.IRepositoriesFactory mockRepFactory = Mock.Of<BL.IRepositoriesFactory>(f => 
                                                        f.CreateComingsRepository() == mockComingsRep.Object);
            BL.Facade facade = new BL.Facade(mockRepFactory);

            // Act
            BL.Coming res = facade.GetComingById(1);

            // Assert
            Assert.NotNull(res);
        }

        [Fact]
        public void TestAddComing()
        {
            // Arrange
            var car = CarObjectMother.DefaultCar().Build();
            var coming = ComingObjectMother.DefaultComing().Build();

            Mock<BL.IComingsRepository> mockComingsRep = new Mock<BL.IComingsRepository>();
            mockComingsRep.Setup(rep => rep.AddComing(It.IsAny<BL.Coming>(), It.IsAny<BL.Car>())).Verifiable();

            Mock<BL.ICarsRepository> mockCarsRep = new Mock<BL.ICarsRepository>();
            mockCarsRep.Setup(rep => rep.AddCar(It.IsAny<BL.Car>())).Verifiable();

            BL.IRepositoriesFactory mockRepFactory = Mock.Of<BL.IRepositoriesFactory>(f => 
                                                        f.CreateComingsRepository() == mockComingsRep.Object &&
                                                        f.CreateCarsRepository() == mockCarsRep.Object);
            BL.Facade facade = new BL.Facade(mockRepFactory);

            // Act
            facade.AddComing(coming, car);

            // Assert
            mockComingsRep.Verify(x => x.AddComing(coming, car), Times.Once);
            mockCarsRep.Verify(x => x.AddCar(It.IsAny<BL.Car>()), Times.Once);
        }

        [Fact]
        public void TestDeleteComing()
        {
            // Arrange
            Mock<BL.IComingsRepository> mockComingsRep = new Mock<BL.IComingsRepository>();
            mockComingsRep.Setup(rep => rep.DeleteComing(It.IsAny<int>())).Verifiable();

            BL.IRepositoriesFactory mockRepFactory = Mock.Of<BL.IRepositoriesFactory>(f => 
                                                        f.CreateComingsRepository() == mockComingsRep.Object);
            BL.Facade facade = new BL.Facade(mockRepFactory);

            // Act
            facade.DeleteComing(1);

            // Assert
            mockComingsRep.Verify(x => x.DeleteComing(1), Times.Once);
        }
    }
}