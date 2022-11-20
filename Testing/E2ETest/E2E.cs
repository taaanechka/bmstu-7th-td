using System;
using Microsoft.EntityFrameworkCore;

using Xunit;
using Allure.Xunit.Attributes;

using BL;
using DB;

namespace E2ETest;

[AllureSuite("E2ETest")]
public class E2E: IDisposable
{
    private string _conn = "Host=localhost; Port=5432; Database=car-accounting-test; Username=user; Password=password";
    private DbContextOptions<ApplicationContext> _options;

    private ApplicationContext _context;

    public E2E()
    {
        _options = new DbContextOptionsBuilder<ApplicationContext>()
                                .UseNpgsql(_conn)
                                .Options;

        _context = new DB.ApplicationContext(_options);
    }

    public void Dispose() {}

    [AllureXunit(DisplayName = "Add And Delete CarComing")]
    public void TestAddAndDeleteCarComing()
    {
        // Arrange
        BL.Facade Facade = new BL.Facade(new RepositoriesFactory(_context));

        var coming = new BL.Coming(0, 3);
        var car = new BL.Car("Number11", 1, 5, 3, 0);

        // Act
        Facade.AddComing(coming, car);

        // Assert
        var comingId = Facade.GetComingIdByCarId(car.Id);
        var retComing = Facade.GetComingById(comingId);
        Assert.Equal(coming.UserId, retComing.UserId);
        Assert.Equal(coming.ComingDate, retComing.ComingDate);

        var retCar = Facade.GetCarById(car.Id);
        Assert.Equal(car.ModelId, retCar.ModelId);
        Assert.Equal(car.EquipmentId, retCar.EquipmentId);
        Assert.Equal(car.ColorId, retCar.ColorId);
        Assert.Equal(comingId, retCar.ComingId);

        // End Act
        Facade.DeleteComing(comingId);

        // End Assert
        Assert.Throws<BL.ComingNotFoundException>(()=> Facade.GetComingById(comingId));
        Assert.Throws<BL.CarNotFoundException>(()=> Facade.GetCarById(car.Id));
    }
}