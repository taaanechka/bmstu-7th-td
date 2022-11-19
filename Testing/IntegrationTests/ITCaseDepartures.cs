using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.EntityFrameworkCore;

using Xunit;
using Allure.Xunit.Attributes;

using DB;
using BL;

using UnitTests.ObjectMothers;

namespace IntegrationTests;

[AllureParentSuite("IntegrationTests")]
[AllureSuite("Departures Tests")]
[Collection("ITCollection")]
public class ITCaseDepartures: IDisposable
{
    private ITFixture _fixture;

    public ITCaseDepartures(ITFixture fixture)
    {
        _fixture = fixture;
    }

    public void Dispose() {}

    [AllureXunit(DisplayName = "GetDepartures")]
    public void TestGetDepartures()
    {
        // Act
        List<BL.Departure> Departures = _fixture.Facade.GetDepartures();

        // Assert
        Assert.Equal(_fixture.Context.Departures.Count(), Departures.Count);
    }

    [AllureXunit(DisplayName = "GetDepartureByIdCorrect")]
    public void TestGetDepartureByIdCorrect()
    {
        // Act
        BL.Departure Departure = _fixture.Facade.GetDepartureById(1);

        // Assert
        Assert.NotNull(Departure);
    }

    [AllureXunit(DisplayName = "GetDepartureByIdUncorrect")]
    public void TestGetDepartureByIdUncorrect()
    {
        // Act-Assert
        Assert.Throws<BL.DepartureNotFoundException>(()=> _fixture.Facade.GetDepartureById(1500));
    }

    [AllureXunit(DisplayName = "AddDepartureUncorrect")]
    public void TestAddDepartureUncorrect()
    {
        // Arrange
        var LinkOwnerCarDeparture = LinkOwnerCarDepartureObjectMother.DefaultLinkOwnerCarDeparture4().Build();
        BL.Departure Departure = DepartureObjectMother.WithoutUserIdDeparture().Build();

        // Act-Assert
        Assert.Throws<BL.DepartureAddException>(()=> _fixture.Facade.AddDeparture(
                                                                Departure, LinkOwnerCarDeparture));
    }

    [AllureXunit(DisplayName = "DeleteDepartureUncorrect")]
    public void TestDeleteDepartureUncorrect()
    {
        // Act-Assert
        Assert.Throws<BL.DepartureDeleteException>(()=> _fixture.Facade.DeleteDeparture(1500));
    }
}