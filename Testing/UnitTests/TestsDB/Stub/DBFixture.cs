using System;

using Microsoft.EntityFrameworkCore;

using Xunit;
// using Xunit.Abstractions;
using Moq;

using BL;
using DB;

using UnitTests.ObjectMothers;

namespace UnitTests.TestsDB
{
    public class DBFixture: IDisposable
    {
        private DbContextOptions<ApplicationContext> _options;

        public ApplicationContext context;

        public DB.UsersRepository usersRep;
        public DB.CarOwnersRepository carOwnersRep;
        public DB.CarsRepository carsRep;
        public DB.ComingsRepository comsRep;
        public DB.DeparturesRepository depsRep;
        public DB.LinksOwnerCarDepartureRepository linksRep;
        public DB.ModelsRepository modelsRep;

        public DBFixture ()
        {
            _options = new DbContextOptionsBuilder<ApplicationContext>()
                            .UseInMemoryDatabase(databaseName: "car-accounting-postgres")
                            .Options;

            context = new ApplicationContext(_options);

            // Users
            context.Users.Add(DB.UserConverter.BLToDB(
                UserObjectMother.DefaultUser1().Build() ));
            context.Users.Add(DB.UserConverter.BLToDB(
                UserObjectMother.DefaultUser2().Build() ));
            context.Users.Add(DB.UserConverter.BLToDB(
                UserObjectMother.DefaultUser3().Build() ));

            // context.SaveChanges();

            // CarOwners
            context.CarOwners.Add(DB.CarOwnerConverter.BLToDB(
                CarOwnerObjectMother.DefaultCarOwner().Build() ));
            context.CarOwners.Add(DB.CarOwnerConverter.BLToDB(
                CarOwnerObjectMother.DefaultCarOwner2().Build() ));
            context.CarOwners.Add(DB.CarOwnerConverter.BLToDB(
                CarOwnerObjectMother.DefaultCarOwner3().Build() ));

            // context.SaveChanges();

            // Cars
            context.Cars.Add(DB.CarConverter.BLToDB(
                CarObjectMother.DefaultCar().Build() ));
            context.Cars.Add(DB.CarConverter.BLToDB(
                CarObjectMother.DefaultCar2().Build() ));
            context.Cars.Add(DB.CarConverter.BLToDB(
                CarObjectMother.DefaultCar3().Build() ));

            // context.SaveChanges();

            // Comings
            context.Comings.Add(DB.ComingConverter.BLToDB(
                ComingObjectMother.DefaultComing().Build() ));
            context.Comings.Add(DB.ComingConverter.BLToDB(
                ComingObjectMother.DefaultComing2().Build() ));
            context.Comings.Add(DB.ComingConverter.BLToDB(
                ComingObjectMother.DefaultComing3().Build() ));

            // context.SaveChanges();

            // Departures
            context.Departures.Add(DB.DepartureConverter.BLToDB(
                DepartureObjectMother.DefaultDeparture().Build() ));
            context.Departures.Add(DB.DepartureConverter.BLToDB(
                DepartureObjectMother.DefaultDeparture2().Build() ));
            context.Departures.Add(DB.DepartureConverter.BLToDB(
                DepartureObjectMother.DefaultDeparture3().Build() ));

            // context.SaveChanges();

            // LinksOwnerCarDeparture
            context.LinksOwnerCarDeparture.Add(DB.LinkOwnerCarDepartureConverter.BLToDB(
                LinkOwnerCarDepartureObjectMother.DefaultLinkOwnerCarDeparture().Build() ));
            context.LinksOwnerCarDeparture.Add(DB.LinkOwnerCarDepartureConverter.BLToDB(
                LinkOwnerCarDepartureObjectMother.DefaultLinkOwnerCarDeparture2().Build() ));
            context.LinksOwnerCarDeparture.Add(DB.LinkOwnerCarDepartureConverter.BLToDB(
                LinkOwnerCarDepartureObjectMother.DefaultLinkOwnerCarDeparture3().Build() ));

            // context.SaveChanges();

            // Models
            context.Models.Add(DB.ModelConverter.BLToDB(
                ModelObjectMother.DefaultModel().Build() ));
            context.Models.Add(DB.ModelConverter.BLToDB(
                ModelObjectMother.DefaultModel2().Build() ));
            context.Models.Add(DB.ModelConverter.BLToDB(
                ModelObjectMother.DefaultModel3().Build() ));

            context.SaveChanges();

            // Repositories
            usersRep = new DB.UsersRepository(context);
            carOwnersRep = new DB.CarOwnersRepository(context);
            carsRep = new DB.CarsRepository(context);
            comsRep = new DB.ComingsRepository(context);
            depsRep = new DB.DeparturesRepository(context);
            linksRep = new DB.LinksOwnerCarDepartureRepository(context);
            modelsRep = new DB.ModelsRepository(context);
        }

        public void Dispose()
        {
            context.ChangeTracker.Clear();
            context.Dispose();
        }
    }

    [CollectionDefinition("DBCollection")]
    public class DBCollection : ICollectionFixture<DBFixture>
    {
    }
}