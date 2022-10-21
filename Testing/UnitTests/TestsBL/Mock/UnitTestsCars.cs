using System;
using System.Collections.Generic;
using Xunit;
using Moq;

using BL;
using UnitTests.ObjectMothers;

namespace UnitTests.TestsBL
{
    public class UnitTestsCars
    {
        [Fact]
        public void TestGetCars()
        {
            // Arrange
            var retCars = new List<BL.Car>() {
                        CarObjectMother.DefaultCar().Build(),
                        CarObjectMother.DefaultCar2().Build()
            };

            Mock<BL.ICarsRepository> mockCarsRep = new Mock<BL.ICarsRepository>();
            mockCarsRep.Setup(r => r.GetCars(It.IsAny<int>(), It.IsAny<int>()))
                        .Returns(retCars);
            
            BL.IRepositoriesFactory mockRepFactory = Mock.Of<BL.IRepositoriesFactory>(f => 
                                                        f.CreateCarsRepository() == mockCarsRep.Object);
            BL.Facade facade = new BL.Facade(mockRepFactory);

            // Act
            List<BL.Car> Cars = facade.GetCars();

            //
            Assert.Equal(retCars.Count, Cars.Count);
        }

        [Fact]
        public void TestGetCarById()
        {
            // Arrange
            BL.Car car = CarObjectMother.DefaultCar().Build();

            Mock<BL.ICarsRepository> mockCarsRep = new Mock<BL.ICarsRepository>();
            mockCarsRep.Setup(rep => rep.GetCarById(It.IsAny<string>())).Returns(car);

            BL.IRepositoriesFactory mockRepFactory = Mock.Of<BL.IRepositoriesFactory>(f => 
                                                        f.CreateCarsRepository() == mockCarsRep.Object);
            BL.Facade facade = new BL.Facade(mockRepFactory);

            // Act
            BL.Car res = facade.GetCarById("Number1");

            // Assert
            Assert.NotNull(res);
        }

        [Fact]
        public void TestUpdateCar()
        {
            // Arrange
            var retCar = CarObjectMother.DefaultCar().Build();
            // var retCar = new CarBLBuilder()
            //             .WithId("Number1")
            //             .WithModelId(1)
            //             .WithEquipmentId(1)
            //             .WithColorId(5)
            //             .WithComingId(1)
            //             .Build();

            // RepositoriesFactory
            Mock<BL.ICarsRepository> mockCarsRep = new Mock<BL.ICarsRepository>();
            mockCarsRep.Setup(rep => rep.GetCarById(It.IsAny<string>())).Returns(retCar);
            mockCarsRep.Setup(rep => rep.UpdateCar(It.IsAny<string>(), It.IsAny<BL.Car>())).Verifiable();

            BL.IRepositoriesFactory mockRepFactory = Mock.Of<BL.IRepositoriesFactory>(f => 
                                                        f.CreateCarsRepository() == mockCarsRep.Object);
            BL.Facade facade = new BL.Facade(mockRepFactory);

            // Act
            facade.UpdateCar("Number1", retCar);

            // Assert
            // mockCarsRep.VerifyAll();
            mockCarsRep.Verify(x => x.UpdateCar("Number1", It.IsAny<BL.Car>()), Times.Once);
        }
    }
}