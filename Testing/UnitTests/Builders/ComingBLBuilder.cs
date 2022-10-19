using System;

using BL;
using UnitTests.Entities;
using UnitTests.Converters;

namespace UnitTests.Builders
{
    public class ComingBLBuilder
    {
        private UnitTests.Entities.Coming _coming;

        public ComingBLBuilder()
        {
            _coming = new UnitTests.Entities.Coming();
        }

        public ComingBLBuilder WithUserId(int userId)
        {
            _coming.UserId = userId;
            return this;
        }

        public ComingBLBuilder WithComingDate(DateTime date)
        {
            _coming.ComingDate = date;
            return this;
        }

        public BL.Coming Build()
        {
            return ComingConverter.TestToBL(_coming);
            // return _coming;
        }
    }
}