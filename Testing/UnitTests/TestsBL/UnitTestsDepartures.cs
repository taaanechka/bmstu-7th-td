using System;
using System.Collections.Generic;
using Xunit;
using Moq;

using BL;
using UnitTests.ObjectMothers;

namespace UnitTests.TestsBL
{
    public class UnitTestDepartures
    {
        [Fact]
        public void TestGetDepartures()
        {
            // Arrange
            var retDepartures = new List<BL.Departure>() {
                        DepartureObjectMother.DefaultDeparture().Build(),
                        DepartureObjectMother.DefaultDeparture2().Build()
            };

            Mock<BL.IDeparturesRepository> mockDeparturesRep = new Mock<BL.IDeparturesRepository>();
            mockDeparturesRep.Setup(r => r.GetDepartures(It.IsAny<int>(), It.IsAny<int>()))
                        .Returns(retDepartures);

            BL.IRepositoriesFactory mockRepFactory = Mock.Of<BL.IRepositoriesFactory>(f => 
                                                        f.CreateDeparturesRepository() == mockDeparturesRep.Object);
            BL.Facade facade = new BL.Facade(mockRepFactory);

            // Act
            List<BL.Departure> Departures = facade.GetDepartures();

            // Assert
            Assert.Equal(retDepartures.Count, Departures.Count);
        }

        [Fact]
        public void TestGetDepartureById()
        {
            // Arrange
            var departure = DepartureObjectMother.DefaultDeparture().Build();

            // RepositoriesFactory
            Mock<BL.IDeparturesRepository> mockDeparturesRep = new Mock<BL.IDeparturesRepository>();
            mockDeparturesRep.Setup(rep => rep.GetDepartureById(It.IsAny<int>())).Returns(departure);

            BL.IRepositoriesFactory mockRepFactory = Mock.Of<BL.IRepositoriesFactory>(f => 
                                                        f.CreateDeparturesRepository() == mockDeparturesRep.Object);
            BL.Facade facade = new BL.Facade(mockRepFactory);

            // Act
            BL.Departure res = facade.GetDepartureById(1);

            // Assert
            Assert.NotNull(res);
            mockDeparturesRep.Verify(x => x.GetDepartureById(1), Times.Once);
        }

        [Fact]
        public void TestAddDeparture()
        {
            // Arrange
            var linkOwnerCarDeparture = LinkOwnerCarDepartureObjectMother
                                        .DefaultLinkOwnerCarDeparture().Build();
            var departure = DepartureObjectMother.DefaultDeparture().Build();

            Mock<BL.IDeparturesRepository> mockDeparturesRep = new Mock<BL.IDeparturesRepository>();
            mockDeparturesRep.Setup(rep => rep.AddDeparture(It.IsAny<BL.Departure>(), It.IsAny<BL.LinkOwnerCarDeparture>())).Verifiable();

            Mock<BL.ILinksOwnerCarDepartureRepository> mockLinksOwnerCarDepartureRep = new Mock<BL.ILinksOwnerCarDepartureRepository>();
            mockLinksOwnerCarDepartureRep.Setup(rep => rep.AddLinkOwnerCarDeparture(It.IsAny<BL.LinkOwnerCarDeparture>())).Verifiable();

            BL.IRepositoriesFactory mockRepFactory = Mock.Of<BL.IRepositoriesFactory>(f => 
                                                        f.CreateDeparturesRepository() == mockDeparturesRep.Object &&
                                                        f.CreateLinksOwnerCarDepartureRepository() ==  mockLinksOwnerCarDepartureRep.Object);
            BL.Facade facade = new BL.Facade(mockRepFactory);

            // Act
            facade.AddDeparture(departure, linkOwnerCarDeparture);

            // Assert
            mockDeparturesRep.Verify(x => x.AddDeparture(departure, linkOwnerCarDeparture), Times.Once);
            mockLinksOwnerCarDepartureRep.Verify(x => 
                x.AddLinkOwnerCarDeparture(It.IsAny<BL.LinkOwnerCarDeparture>()), Times.Once);
        }

        [Fact]
        public void TestDeleteDeparture()
        {
            // Arrange
            Mock<BL.IDeparturesRepository> mockDeparturesRep = new Mock<BL.IDeparturesRepository>();
            mockDeparturesRep.Setup(rep => rep.DeleteDeparture(It.IsAny<int>())).Verifiable();

            BL.IRepositoriesFactory mockRepFactory = Mock.Of<BL.IRepositoriesFactory>(f => 
                                                        f.CreateDeparturesRepository() == mockDeparturesRep.Object);
            BL.Facade facade = new BL.Facade(mockRepFactory);

            // Act
            facade.DeleteDeparture(1);

            // Assert
            mockDeparturesRep.Verify(x => x.DeleteDeparture(1), Times.Once);
        }
    }
}