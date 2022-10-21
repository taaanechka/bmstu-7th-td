using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.EntityFrameworkCore;
// using EntityFrameworkCoreMock;

using Xunit;
using Xunit.Abstractions;
using Moq;

using DB;
using BL;

using UnitTests.ObjectMothers;

namespace UnitTests.TestsDB;

[Collection("DBCollection")]
public class UnitTestLinksOwnerCarDeparture: IDisposable
{
    private DBFixture _fixture;
    public UnitTestLinksOwnerCarDeparture(DBFixture fixture)
    {
        _fixture = fixture;
    }

    public void Dispose() {}

    [Fact]
    public void TestGetLinksOwnerCarDeparture()
    {
        // Act
        List<BL.LinkOwnerCarDeparture> LinksOwnerCarDeparture = _fixture.linksRep.GetLinksOwnerCarDeparture();

        // Assert
        Assert.Equal(_fixture.context.LinksOwnerCarDeparture.Count(), LinksOwnerCarDeparture.Count);
    }

    [Fact]
    public void TestGetLinkOwnerCarDepartureByIdCorrect()
    {
        // Act
        var LinkOwnerCarDeparture = _fixture.linksRep.GetLinkOwnerCarDepartureById(1);

        // Assert
        Assert.NotNull(LinkOwnerCarDeparture);
    }

    [Fact]
    public void TestGetLinkOwnerCarDepartureByIdUncorrect()
    {
        // Act-Assert
        Assert.Throws<DB.LinkOwnerCarDepartureNotFoundException>(()=> _fixture.linksRep
                                                                        .GetLinkOwnerCarDepartureById(5));
    }

    [Fact]
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

    [Fact]
    public void TestAddLinkOwnerCarDepartureUncorrect()
    {
        // Arrange
        var LinkOwnerCarDeparture = LinkOwnerCarDepartureObjectMother.WithoutCarIdIdLinkOwnerCarDeparture()
                                    .Build();

        // Assert
        Assert.Throws<DB.LinksOwnerCarDepartureValidatorFailException>(()=> _fixture.linksRep
                                                            .AddLinkOwnerCarDeparture(LinkOwnerCarDeparture));
    }

    [Fact]
    public void TestDeleteLinkOwnerCarDepartureCorrect()
    {
        // Arrange
        var count = _fixture.context.LinksOwnerCarDeparture.Count() - 1;

        // Act
        _fixture.linksRep.DeleteLinkOwnerCarDeparture(2);

        // Assert
        Assert.Equal(count, _fixture.context.LinksOwnerCarDeparture.Count());
    }

    [Fact]
    public void TestDeleteLinkOwnerCarDepartureUncorrect()
    {
        // Act-Assert
        Assert.Throws<DB.LinkOwnerCarDepartureNotFoundException>(()=> _fixture.linksRep
                                                                    .DeleteLinkOwnerCarDeparture(5));
    }
}