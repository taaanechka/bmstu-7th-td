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
public class UnitTestCars: IDisposable
{
    private DBFixture _fixture;

    public UnitTestCars(DBFixture fixture)
    {
        _fixture = fixture;
    }

    public void Dispose() {}

    [Fact]
    public void TestGetCars()
    {
        // Act
        List<BL.Car> Cars = _fixture.carsRep.GetCars();

        // Assert
        Assert.Equal(_fixture.context.Cars.Count(), Cars.Count);
    }

    [Fact]
    public void TestGetCarByIdCorrect()
    {
        // Act
        BL.Car Car = _fixture.carsRep.GetCarById("Number1");

        // Assert
        Assert.NotNull(Car);
    }

    [Fact]
    public void TestGetCarByIdUncorrect()
    {
        // Act-Assert
        Assert.Throws<DB.CarNotFoundException>(()=> _fixture.carsRep.GetCarById("Number5"));
    }

    [Fact]
    public void TestAddCarCorrect()
    {
        // Arrange
        var Car = CarObjectMother.DefaultCar4().Build();

        var count = _fixture.context.Cars.Count() + 1;

        // Act
        _fixture.carsRep.AddCar(Car);

        // Assert
        Assert.Equal(count, _fixture.context.Cars.Count());
    }

    [Fact]
    public void TestAddCarUncorrect()
    {
        // Arrange
        var Car = CarObjectMother.WithoutNumberCar().Build();

        // Act-Assert
        Assert.Throws<DB.CarsValidatorFailException>(()=> _fixture.carsRep.AddCar(Car));
    }

    [Fact]
    public void TestUpdateCarCorrect()
    {
        // Arrange
        BL.Car CarUpd = CarObjectMother.UpdDefaultCar().Build();

        // Act
        _fixture.carsRep.UpdateCar("Number1", CarUpd);

        var CarNew = _fixture.carsRep.GetCarById("Number1");

        // Assert
        Assert.Equal(CarUpd.EquipmentId, CarNew.EquipmentId);
        Assert.Equal(CarUpd.ColorId, CarNew.ColorId);
    }

    [Fact]
    public void TestUpdateCarUncorrect()
    {
        // Arrange
        var CarUpd = CarObjectMother.WithoutColorCar().Build();

        // Act-Assert
        Assert.Throws<DB.CarsValidatorFailException>(()=> _fixture.carsRep.UpdateCar("Number3", CarUpd));
    }

    [Fact]
    public void TestDeleteCarCorrect()
    {
        // Arrange
        var count = _fixture.context.Cars.Count() - 1;

        // Act
        _fixture.carsRep.DeleteCar("Number3");

        // Assert
        Assert.Equal(count, _fixture.context.Cars.Count());
    }

    [Fact]
    public void TestDeleteCarUncorrect()
    {
        // Act-Assert
        Assert.Throws<DB.CarNotFoundException>(()=> _fixture.carsRep.DeleteCar("Number5"));
    }
}