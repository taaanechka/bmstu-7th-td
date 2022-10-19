using BL;
using UnitTests.Entities;

namespace UnitTests.Converters
{
    public class UserConverter
    {
        public static BL.User TestToBL(UnitTests.Entities.User User)
        {
            return new BL.User(User.Id, User.Name, User.Surname, User.Login, User.Password, User.UserType);
        }

        public static UnitTests.Entities.User BLToTest(BL.User UserBL)
        {
            UnitTests.Entities.User user = new UnitTests.Entities.User();
            // user.Id = UserBL.Id;
            user.Name = UserBL.Name;
            user.Surname = UserBL.Surname;
            user.Login = UserBL.Login;
            user.Password = UserBL.Password;
            user.UserType = UserBL.UserType;

            return user;
        }
    }
}