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
[AllureSuite("Comings Tests")]
[Collection("DBCollection")]
public class UnitTestComings: IDisposable
{
    private DBFixture _fixture;

    public UnitTestComings(DBFixture fixture)
    {
        _fixture = fixture;
    }

    public void Dispose() {}

    [AllureXunit(DisplayName = "GetComings")]
    public void TestGetComings()
    {
        // Act
        List<BL.Coming> Comings = _fixture.comsRep.GetComings();

        // Assert
        Assert.Equal(_fixture.context.Comings.Count(), Comings.Count);
    }

    [AllureXunit(DisplayName = "GetComingByIdCorrect")]
    public void TestGetComingByIdCorrect()
    {
        // Act
        BL.Coming Coming = _fixture.comsRep.GetComingById(1);

        // Assert
        Assert.NotNull(Coming);
    }

    [AllureXunit(DisplayName = "GetComingByIdUncorrect")]
    public void TestGetComingByIdUncorrect()
    {
        // Act-Assert
        Assert.Throws<DB.ComingNotFoundException>(()=> _fixture.comsRep.GetComingById(5));
    }

    [AllureXunit(DisplayName = "AddComingCorrect")]
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

    [AllureXunit(DisplayName = "AddComingUncorrect")]
    public void TestAddComingUncorrect()
    {
        // Arrange
        BL.Car car = CarObjectMother.DefaultCar5().Build();
        var Coming = ComingObjectMother.WithoutUserIdComing().Build();

        // Act-Assert
        Assert.Throws<DB.ComingsValidatorFailException>(()=> _fixture.comsRep.AddComing(Coming, car));
    }

    [AllureXunit(DisplayName = "DeleteComingCorrect")]
    public void TestDeleteComingCorrect()
    {
        // Arrange
        var count = _fixture.context.Comings.Count() - 1;

        // Act
        _fixture.comsRep.DeleteComing(3);

        // Assert
        Assert.Equal(count, _fixture.context.Comings.Count());
    }

    [AllureXunit(DisplayName = "DeleteComingUncorrect")]
    public void TestDeleteComingUncorrect()
    {
        // Act-Assert
        Assert.Throws<DB.ComingNotFoundException>(()=> _fixture.comsRep.DeleteComing(5));
    }
}