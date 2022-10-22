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
[AllureSuite("LinksOwnerCarDeparture Tests")]
[Collection("DBCollection")]
public class UnitTestLinksOwnerCarDeparture: IDisposable
{
    private DBFixture _fixture;
    public UnitTestLinksOwnerCarDeparture(DBFixture fixture)
    {
        _fixture = fixture;
    }

    public void Dispose() {}

    [AllureXunit(DisplayName = "GetLinksOwnerCarDeparture")]
    public void TestGetLinksOwnerCarDeparture()
    {
        // Act
        List<BL.LinkOwnerCarDeparture> LinksOwnerCarDeparture = _fixture.linksRep.GetLinksOwnerCarDeparture();

        // Assert
        Assert.Equal(_fixture.context.LinksOwnerCarDeparture.Count(), LinksOwnerCarDeparture.Count);
    }

    [AllureXunit(DisplayName = "GetLinkOwnerCarDepartureByIdCorrect")]
    public void TestGetLinkOwnerCarDepartureByIdCorrect()
    {
        // Act
        var LinkOwnerCarDeparture = _fixture.linksRep.GetLinkOwnerCarDepartureById(1);

        // Assert
        Assert.NotNull(LinkOwnerCarDeparture);
    }

    [AllureXunit(DisplayName = "GetLinkOwnerCarDepartureByIdUncorrect")]
    public void TestGetLinkOwnerCarDepartureByIdUncorrect()
    {
        // Act-Assert
        Assert.Throws<DB.LinkOwnerCarDepartureNotFoundException>(()=> _fixture.linksRep
                                                                        .GetLinkOwnerCarDepartureById(5));
    }

    [AllureXunit(DisplayName = "AddLinkOwnerCarDepartureCorrect")]
    public void TestAddLinkOwnerCarDepartureCorrect()
    {
        // Arrange
        var LinkOwnerCarDeparture = LinkOwnerCarDepartureObjectMother.DefaultLinkOwnerCarDeparture4().Build();

        var count = _fixture.context.LinksOwnerCarDeparture.Count() + 1;

        // Act
        _fixture.linksRep.AddLinkOwnerCarDeparture(LinkOwnerCarDeparture);

        // Assert
        Assert.Equal(count, _fixture.context.LinksOwnerCarDeparture.Count());
    }

    [AllureXunit(DisplayName = "AddLinkOwnerCarDepartureUncorrect")]
    public void TestAddLinkOwnerCarDepartureUncorrect()
    {
        // Arrange
        var LinkOwnerCarDeparture = LinkOwnerCarDepartureObjectMother.WithoutCarIdIdLinkOwnerCarDeparture()
                                    .Build();

        // Assert
        Assert.Throws<DB.LinksOwnerCarDepartureValidatorFailException>(()=> _fixture.linksRep
                                                            .AddLinkOwnerCarDeparture(LinkOwnerCarDeparture));
    }

    [AllureXunit(DisplayName = "DeleteLinkOwnerCarDepartureCorrect")]
    public void TestDeleteLinkOwnerCarDepartureCorrect()
    {
        // Arrange
        var count = _fixture.context.LinksOwnerCarDeparture.Count() - 1;

        // Act
        _fixture.linksRep.DeleteLinkOwnerCarDeparture(2);

        // Assert
        Assert.Equal(count, _fixture.context.LinksOwnerCarDeparture.Count());
    }

    [AllureXunit(DisplayName = "DeleteLinkOwnerCarDepartureUncorrect")]
    public void TestDeleteLinkOwnerCarDepartureUncorrect()
    {
        // Act-Assert
        Assert.Throws<DB.LinkOwnerCarDepartureNotFoundException>(()=> _fixture.linksRep
                                                                    .DeleteLinkOwnerCarDeparture(5));
    }
}