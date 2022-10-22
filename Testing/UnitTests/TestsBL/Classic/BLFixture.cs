using System;

using Microsoft.EntityFrameworkCore;

using Xunit;
// using Xunit.Abstractions;
using Moq;

using BL;
using DB;

using UnitTests.ObjectMothers;

namespace UnitTests.TestsBL.Classic
{
    public class BLFixture: IDisposable
    {
        private string _conn = "Host=localhost; Port=5432; Database=car-accounting-test; Username=user; Password=password";
        private DbContextOptions<ApplicationContext> _options;

        public ApplicationContext Context;

        public BL.Facade Facade;

        public BLFixture ()
        {
            _options = new DbContextOptionsBuilder<ApplicationContext>()
                                .UseNpgsql(_conn)
                                .Options;

            Context = new DB.ApplicationContext(_options);

            // // Users
            // Context.Users.Add(DB.UserConverter.BLToDB(
            //     UserObjectMother.DefaultUser1().Build() ));
            // Context.SaveChanges();
            // Context.Users.Add(DB.UserConverter.BLToDB(
            //     UserObjectMother.DefaultUser2().Build() ));
            // Context.SaveChanges();
            // Context.Users.Add(DB.UserConverter.BLToDB(
            //     UserObjectMother.DefaultUser3().Build() ));
            // Context.SaveChanges();

            Facade = new BL.Facade(new RepositoriesFactory(Context));
        }

        public void Dispose()
        {
            Context.ChangeTracker.Clear();
            Context.Dispose();
        }
    }

    [CollectionDefinition("BLCollection")]
    public class BLCollection : ICollectionFixture<BLFixture>
    {
    }
}