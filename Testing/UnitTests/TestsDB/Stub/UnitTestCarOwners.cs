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
public class UnitTestCarOwners: IDisposable
{
    private DBFixture _fixture;

    public UnitTestCarOwners(DBFixture fixture)
    {
        _fixture = fixture;
    }

    public void Dispose() {}

    [Fact]
    public void TestGetCarOwners()
    {
        // Act
        List<BL.CarOwner> CarOwners = _fixture.carOwnersRep.GetCarOwners();

        // Assert
        Assert.Equal(_fixture.context.CarOwners.Count(), CarOwners.Count);
    }

    [Fact]
    public void TestGetCarOwnerByIdCorrect()
    {
        // Act
        BL.CarOwner CarOwner = _fixture.carOwnersRep.GetCarOwnerById(1);

        // Assert
        Assert.NotNull(CarOwner);
    }

    [Fact]
    public void TestGetCarOwnerByIdUncorrect()
    {
        // Act-Assert
        Assert.Throws<DB.CarOwnerNotFoundException>(()=> _fixture.carOwnersRep.GetCarOwnerById(5));
    }

    [Fact]
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

    [Fact]
    public void TestAddCarOwnerUncorrect()
    {
        // Arrange
        var CarOwner = CarOwnerObjectMother.WithoutNameCarOwner().Build();

        // Act-Assert
        Assert.Throws<DB.CarOwnersValidatorFailException>(()=> _fixture.carOwnersRep.AddCarOwner(CarOwner));
    }

    [Fact]
    public void TestUpdateCarOwnerCorrect()
    {
        // Arrange
        var CarOwnerUpd = CarOwnerObjectMother.UpdCarOwner().Build();

        // Act
        _fixture.carOwnersRep.UpdateCarOwner(2, CarOwnerUpd);

        var CarOwnerNew = _fixture.carOwnersRep.GetCarOwnerById(2);

        // Assert
        Assert.Equal("NameDefault2", CarOwnerNew.Name);
        Assert.Equal("SurnameUpd", CarOwnerNew.Surname);
        Assert.Equal("EmailDefault2", CarOwnerNew.Email);
    }

    [Fact]
    public void TestUpdateCarOwnerUncorrect()
    {
        // Arrange
        var CarOwnerUpd = CarOwnerObjectMother.WithoutEmailCarOwner().Build();

        // Act-Assert
        Assert.Throws<DB.CarOwnersValidatorFailException>(()=> _fixture.carOwnersRep.UpdateCarOwner(2, CarOwnerUpd));
    }

    [Fact]
    public void TestDeleteCarOwnerCorrect()
    {
        // Arrange
        var count = _fixture.context.CarOwners.Count() - 1;

        // Act
        _fixture.carOwnersRep.DeleteCarOwner(3);

        // Assert
        Assert.Equal(count, _fixture.context.CarOwners.Count());
    }

    [Fact]
    public void TestDeleteCarOwnerUncorrect()
    {
        // Act-Assert
        Assert.Throws<DB.CarOwnerNotFoundException>(()=> _fixture.carOwnersRep.DeleteCarOwner(5));
    }
}