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
[AllureSuite("Comings Tests")]
[Collection("ITCollection")]
public class ITCaseComings: IDisposable
{
    private ITFixture _fixture;

    public ITCaseComings(ITFixture fixture)
    {
        _fixture = fixture;
    }

    public void Dispose() {}

    [AllureXunit(DisplayName = "GetComings")]
    public void TestGetComings()
    {
        // Act
        List<BL.Coming> Comings = _fixture.Facade.GetComings();

        // Assert
        Assert.Equal(_fixture.Context.Comings.Count(), Comings.Count);
    }

    [AllureXunit(DisplayName = "GetComingByIdCorrect")]
    public void TestGetComingByIdCorrect()
    {
        // Act
        BL.Coming Coming = _fixture.Facade.GetComingById(1);

        // Assert
        Assert.NotNull(Coming);
    }

    [AllureXunit(DisplayName = "GetComingByIdUncorrect")]
    public void TestGetComingByIdUncorrect()
    {
        // Act-Assert
        Assert.Throws<BL.ComingNotFoundException>(()=> _fixture.Facade.GetComingById(1500));
    }

    [AllureXunit(DisplayName = "AddComingUncorrect")]
    public void TestAddComingUncorrect()
    {
        // Arrange
        BL.Car car = CarObjectMother.DefaultCar5().Build();
        var Coming = ComingObjectMother.WithoutUserIdComing().Build();

        // Act-Assert
        Assert.Throws<BL.ComingsValidatorFailException>(()=> _fixture.Facade.AddComing(Coming, car));
    }

    [AllureXunit(DisplayName = "DeleteComingCorrect")]
    public void TestDeleteComingCorrect()
    {
        // Arrange
        var count = _fixture.Context.Comings.Count() - 1;

        // Act
        _fixture.Facade.DeleteComing(3);

        // Assert
        Assert.Equal(count, _fixture.Context.Comings.Count());
    }

    [AllureXunit(DisplayName = "DeleteComingUncorrect")]
    public void TestDeleteComingUncorrect()
    {
        // Act-Assert
        Assert.Throws<BL.ComingDeleteException>(()=> _fixture.Facade.DeleteComing(1500));
    }
}