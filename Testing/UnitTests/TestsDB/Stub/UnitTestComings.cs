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
public class UnitTestComings: IDisposable
{
    private DBFixture _fixture;

    public UnitTestComings(DBFixture fixture)
    {
        _fixture = fixture;
    }

    public void Dispose() {}

    [Fact]
    public void TestGetComings()
    {
        // Act
        List<BL.Coming> Comings = _fixture.comsRep.GetComings();

        // Assert
        Assert.Equal(_fixture.context.Comings.Count(), Comings.Count);
    }

    [Fact]
    public void TestGetComingByIdCorrect()
    {
        // Act
        BL.Coming Coming = _fixture.comsRep.GetComingById(1);

        // Assert
        Assert.NotNull(Coming);
    }

    [Fact]
    public void TestGetComingByIdUncorrect()
    {
        // Act-Assert
        Assert.Throws<DB.ComingNotFoundException>(()=> _fixture.comsRep.GetComingById(5));
    }

    [Fact]
    public void TestAddComingCorrect()
    {
        // Arrange
        var car = CarObjectMother.DefaultCar5().Build();
        var Coming = ComingObjectMother.DefaultComing4().Build();

        var count = _fixture.context.Comings.Count() + 1;

        // Act
        _fixture.comsRep.AddComing(Coming, car);

        // Assert
        Assert.Equal(count, _fixture.context.Comings.Count());
    }

    [Fact]
    public void TestAddComingUncorrect()
    {
        // Arrange
        BL.Car car = CarObjectMother.DefaultCar5().Build();
        var Coming = ComingObjectMother.WithoutUserIdComing().Build();

        // Act-Assert
        Assert.Throws<DB.ComingsValidatorFailException>(()=> _fixture.comsRep.AddComing(Coming, car));
    }

    [Fact]
    public void TestDeleteComingCorrect()
    {
        // Arrange
        var count = _fixture.context.Comings.Count() - 1;

        // Act
        _fixture.comsRep.DeleteComing(3);

        // Assert
        Assert.Equal(count, _fixture.context.Comings.Count());
    }

    [Fact]
    public void TestDeleteComingUncorrect()
    {
        // Act-Assert
        Assert.Throws<DB.ComingNotFoundException>(()=> _fixture.comsRep.DeleteComing(5));
    }
}