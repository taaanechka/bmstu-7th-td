using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.EntityFrameworkCore;
// using EntityFrameworkCoreMock;

using Xunit;
using Xunit.Abstractions;
using Moq;
using Allure.Xunit;
using Allure.Xunit.Attributes;

using DB;
using BL;

using UnitTests.ObjectMothers;

namespace UnitTests.TestsDB;

[AllureParentSuite("DBTests.Stub")]
[AllureSuite("Departures Tests")]
[Collection("DBCollection")]
public class UnitTestDepartures: IDisposable
{
    private DBFixture _fixture;

    public UnitTestDepartures(DBFixture fixture)
    {
        _fixture = fixture;
    }

    public void Dispose() {}

    [AllureXunit(DisplayName = "GetDepartures")]
    public void TestGetDepartures()
    {
        // Act
        List<BL.Departure> Departures = _fixture.depsRep.GetDepartures();

        // Assert
        Assert.Equal(_fixture.context.Departures.Count(), Departures.Count);
    }

    [AllureXunit(DisplayName = "GetDepartureByIdCorrect")]
    public void TestGetDepartureByIdCorrect()
    {
        // Act
        BL.Departure Departure = _fixture.depsRep.GetDepartureById(1);

        // Assert
        Assert.NotNull(Departure);
    }

    [AllureXunit(DisplayName = "GetDepartureByIdUncorrect")]
    public void TestGetDepartureByIdUncorrect()
    {
        // Act-Assert
        Assert.Throws<DB.DepartureNotFoundException>(()=> _fixture.depsRep.GetDepartureById(5));
    }

    [AllureXunit(DisplayName = "AddDepartureCorrect")]
    public void TestAddDepartureCorrect()
    {   
        // Arrange
        var LinkOwnerCarDeparture = LinkOwnerCarDepartureObjectMother.DefaultLinkOwnerCarDeparture4().Build();
        BL.Departure Departure = DepartureObjectMother.DefaultDeparture4().Build();

        var count = _fixture.context.Departures.Count() + 1;

        // Act
        _fixture.depsRep.AddDeparture(Departure, LinkOwnerCarDeparture);

        // Assert
        Assert.Equal(count, _fixture.context.Departures.Count());
    }

    [AllureXunit(DisplayName = "AddDepartureUncorrect")]
    public void TestAddDepartureUncorrect()
    {
        // Arrange
        var LinkOwnerCarDeparture = LinkOwnerCarDepartureObjectMother.DefaultLinkOwnerCarDeparture4().Build();
        BL.Departure Departure = DepartureObjectMother.WithoutUserIdDeparture().Build();

        // Act-Assert
        Assert.Throws<DB.DeparturesValidatorFailException>(()=> _fixture.depsRep.AddDeparture(
                                                                Departure, LinkOwnerCarDeparture));
    }

    [AllureXunit(DisplayName = "DeleteDepartureCorrect")]
    public void TestDeleteDepartureCorrect()
    {
        // Arrange
        var count = _fixture.context.Departures.Count() - 1;

        // Act
        _fixture.depsRep.DeleteDeparture(3);

        // Assert
        Assert.Equal(count, _fixture.context.Departures.Count());
    }

    [AllureXunit(DisplayName = "DeleteDepartureUncorrect")]
    public void TestDeleteDepartureUncorrect()
    {
        // Act-Assert
        Assert.Throws<DB.DepartureNotFoundException>(()=> _fixture.depsRep.DeleteDeparture(5));
    }
}