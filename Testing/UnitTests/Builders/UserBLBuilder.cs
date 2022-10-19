using BL;
using UnitTests.Entities;
using UnitTests.Converters;

namespace UnitTests.Builders
{
    public class UserBLBuilder
    {
        private UnitTests.Entities.User _user;

        public UserBLBuilder()
        {
            // _user = new BL.User(1, "", "", "", "", BL.Permissions.EMPLOYEE);
            _user = new UnitTests.Entities.User();
        }

        public UserBLBuilder WithName(string name)
        {
            _user.Name = name;
            return this;
        }

        public UserBLBuilder WithSurname(string surname)
        {
            _user.Surname = surname;
            return this;
        }

        public UserBLBuilder WithLogin(string login)
        {
            _user.Login = login;
            return this;
        }

        public UserBLBuilder WithPassword(string password)
        {
            _user.Password = password;
            return this;
        }

        public UserBLBuilder WithUserType(BL.Permissions userType)
        {
            _user.UserType = userType;
            return this;
        }

        public BL.User Build()
        {
            return UserConverter.TestToBL(_user);
            // return _user;
        }
    }
}