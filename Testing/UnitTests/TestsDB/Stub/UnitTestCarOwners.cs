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
[AllureSuite("CarOwners Tests")]
[Collection("DBCollection")]
public class UnitTestCarOwners: IDisposable
{
    private DBFixture _fixture;

    public UnitTestCarOwners(DBFixture fixture)
    {
        _fixture = fixture;
    }

    public void Dispose() {}

    [AllureXunit(DisplayName = "GetCarOwners")]
    public void TestGetCarOwners()
    {
        // Act
        List<BL.CarOwner> CarOwners = _fixture.carOwnersRep.GetCarOwners();

        // Assert
        Assert.Equal(_fixture.context.CarOwners.Count(), CarOwners.Count);
    }

    [AllureXunit(DisplayName = "GetCarOwnerByIdCorrect")]
    public void TestGetCarOwnerByIdCorrect()
    {
        // Act
        BL.CarOwner CarOwner = _fixture.carOwnersRep.GetCarOwnerById(1);

        // Assert
        Assert.NotNull(CarOwner);
    }

    [AllureXunit(DisplayName = "GetCarOwnerByIdUncorrect")]
    public void TestGetCarOwnerByIdUncorrect()
    {
        // Act-Assert
        Assert.Throws<DB.CarOwnerNotFoundException>(()=> _fixture.carOwnersRep.GetCarOwnerById(5));
    }

    [AllureXunit(DisplayName = "AddCarOwnerCorrect")]
    public void TestAddCarOwnerCorrect()
    {
        // Arrange
        var CarOwner = CarOwnerObjectMother.DefaultCarOwner4().Build();

        var count = _fixture.context.CarOwners.Count() + 1;

        // Act
        _fixture.carOwnersRep.AddCarOwner(CarOwner);

        // Assert
        Assert.Equal(count, _fixture.context.CarOwners.Count());
    }

    [AllureXunit(DisplayName = "AddCarOwnerUncorrect")]
    public void TestAddCarOwnerUncorrect()
    {
        // Arrange
        var CarOwner = CarOwnerObjectMother.WithoutNameCarOwner().Build();

        // Act-Assert
        Assert.Throws<DB.CarOwnersValidatorFailException>(()=> _fixture.carOwnersRep.AddCarOwner(CarOwner));
    }

    [AllureXunit(DisplayName = "UpdateCarOwnerCorrect")]
    public void TestUpdateCarOwnerCorrect()
    {
        // Arrange
        var CarOwnerUpd = CarOwnerObjectMother.UpdCarOwner().Build();

        // Act
        _fixture.carOwnersRep.UpdateCarOwner(2, CarOwnerUpd);

        var CarOwnerNew = _fixture.carOwnersRep.GetCarOwnerById(2);

        // Assert
        Assert.Equal(CarOwnerUpd.Name, CarOwnerNew.Name);
        Assert.Equal(CarOwnerUpd.Surname, CarOwnerNew.Surname);
        Assert.Equal(CarOwnerUpd.Email, CarOwnerNew.Email);
    }

    [AllureXunit(DisplayName = "UpdateCarOwnerUncorrect")]
    public void TestUpdateCarOwnerUncorrect()
    {
        // Arrange
        var CarOwnerUpd = CarOwnerObjectMother.WithoutEmailCarOwner().Build();

        // Act-Assert
        Assert.Throws<DB.CarOwnersValidatorFailException>(()=> _fixture.carOwnersRep.UpdateCarOwner(2, CarOwnerUpd));
    }

    [AllureXunit(DisplayName = "DeleteCarOwnerCorrect")]
    public void TestDeleteCarOwnerCorrect()
    {
        // Arrange
        var count = _fixture.context.CarOwners.Count() - 1;

        // Act
        _fixture.carOwnersRep.DeleteCarOwner(3);

        // Assert
        Assert.Equal(count, _fixture.context.CarOwners.Count());
    }

    [AllureXunit(DisplayName = "DeleteCarOwnerUncorrect")]
    public void TestDeleteCarOwnerUncorrect()
    {
        // Act-Assert
        Assert.Throws<DB.CarOwnerNotFoundException>(()=> _fixture.carOwnersRep.DeleteCarOwner(5));
    }
}