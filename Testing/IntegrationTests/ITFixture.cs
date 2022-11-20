using System;

using Microsoft.EntityFrameworkCore;

using Xunit;
// using Xunit.Abstractions;

using BL;
using DB;

namespace IntegrationTests
{
    public class ITFixture: IDisposable
    {
        private string _conn = "Host=localhost; Port=5432; Database=car-accounting-test; Username=user; Password=password";
        private DbContextOptions<ApplicationContext> _options;

        public ApplicationContext Context;

        public BL.Facade Facade;

        public ITFixture ()
        {
            _options = new DbContextOptionsBuilder<ApplicationContext>()
                                .UseNpgsql(_conn)
                                .Options;

            Context = new DB.ApplicationContext(_options);

            Facade = new BL.Facade(new RepositoriesFactory(Context));
        }

        public void Dispose()
        {
            Context.ChangeTracker.Clear();
            Context.Dispose();
        }
    }

    [CollectionDefinition("ITCollection")]
    public class ITCollection : ICollectionFixture<ITFixture>
    {
    }
}