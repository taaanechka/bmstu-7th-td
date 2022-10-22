using System;
using System.Collections.Generic;
using Xunit;
using Moq;
using Allure.Xunit;
using Allure.Xunit.Attributes;

using BL;
using UnitTests.ObjectMothers;

namespace UnitTests.TestsBL.Moq
{
    [AllureParentSuite("BLTests.Mock")]
    [AllureSuite("LinksOwnerCarDeparture Tests")]
    public class UnitTestLinksOwnerCarDeparture
    {
        [AllureXunit(DisplayName = "GetLinkOwnerCarDepartureById")]
        public void TestGetLinkOwnerCarDepartureById()
        {
            // Arrange
            var linkOwnerCarDeparture = LinkOwnerCarDepartureObjectMother
                                        .DefaultLinkOwnerCarDeparture().Build();

            Mock<BL.ILinksOwnerCarDepartureRepository> mockLinksOwnerCarDepartureRep = new Mock<BL.ILinksOwnerCarDepartureRepository>();
            mockLinksOwnerCarDepartureRep.Setup(rep => rep.GetLinkOwnerCarDepartureById(It.IsAny<int>())).Returns(linkOwnerCarDeparture);

            BL.IRepositoriesFactory mockRepFactory = Mock.Of<BL.IRepositoriesFactory>(f => 
                                                        f.CreateLinksOwnerCarDepartureRepository() == mockLinksOwnerCarDepartureRep.Object);
            BL.Facade facade = new BL.Facade(mockRepFactory);

            // Act
            BL.LinkOwnerCarDeparture res = facade.GetLinkOwnerCarDepartureById(1);

            // Assert
            Assert.NotNull(res);
            mockLinksOwnerCarDepartureRep.Verify(x =>
                x.GetLinkOwnerCarDepartureById(1), Times.Once);
        }

        [AllureXunit(DisplayName = "AddLinkOwnerCarDeparture")]
        public void TestAddLinkOwnerCarDeparture()
        {
            // Arrange
            var linkOwnerCarDeparture = LinkOwnerCarDepartureObjectMother
                                        .DefaultLinkOwnerCarDeparture().Build();

            Mock<BL.ILinksOwnerCarDepartureRepository> mockLinksOwnerCarDepartureRep = new Mock<BL.ILinksOwnerCarDepartureRepository>();
            mockLinksOwnerCarDepartureRep.Setup(rep => rep.AddLinkOwnerCarDeparture(It.IsAny<BL.LinkOwnerCarDeparture>())).Verifiable();

            BL.IRepositoriesFactory mockRepFactory = Mock.Of<BL.IRepositoriesFactory>(f => 
                                                        f.CreateLinksOwnerCarDepartureRepository() == mockLinksOwnerCarDepartureRep.Object);
            BL.Facade facade = new BL.Facade(mockRepFactory);

            // Act
            facade.AddLinkOwnerCarDeparture(linkOwnerCarDeparture);

            // Assert
            mockLinksOwnerCarDepartureRep.Verify(x => x.AddLinkOwnerCarDeparture(linkOwnerCarDeparture), Times.Once);
        }

        [AllureXunit(DisplayName = "DeleteLinkOwnerCarDeparture")]
        public void TestDeleteLinkOwnerCarDeparture()
        {
            // Arrange
            Mock<BL.ILinksOwnerCarDepartureRepository> mockLinksOwnerCarDepartureRep = new Mock<BL.ILinksOwnerCarDepartureRepository>();
            mockLinksOwnerCarDepartureRep.Setup(rep => rep.DeleteLinkOwnerCarDeparture(It.IsAny<int>())).Verifiable();

            BL.IRepositoriesFactory mockRepFactory = Mock.Of<BL.IRepositoriesFactory>(f => 
                                                        f.CreateLinksOwnerCarDepartureRepository() == mockLinksOwnerCarDepartureRep.Object);
            BL.Facade facade = new BL.Facade(mockRepFactory);

            // Act
            facade.DeleteLinkOwnerCarDeparture(1);

            // Assert
            mockLinksOwnerCarDepartureRep.Verify(x => x.DeleteLinkOwnerCarDeparture(1), Times.Once);
        }
    }
}