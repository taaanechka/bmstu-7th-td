using UnitTests.Builders;
using BL;

namespace UnitTests.ObjectMothers
{
    public class UserObjectMother
    {
        public static UserBLBuilder DefaultUser() 
        {
            return new UserBLBuilder()
                        .WithName("NameEmployee")
                        .WithSurname("SurnameEmployee")
                        .WithLogin("LoginEmployee")
                        .WithPassword("123123")
                        .WithUserType(Permissions.EMPLOYEE);
        }

        public static UserBLBuilder AnalystUser() 
        {
            return new UserBLBuilder()
                        .WithName("NameAnalyst")
                        .WithSurname("SurnameAnalyst")
                        .WithLogin("LoginAnalyst")
                        .WithPassword("456456")
                        .WithUserType(Permissions.ANALYST);
        }

        public static UserBLBuilder AdminUser() 
        {
            return new UserBLBuilder()
                        .WithName("NameAdmin")
                        .WithSurname("SurnameAdmin")
                        .WithLogin("LoginAdmin")
                        .WithPassword("789789")
                        .WithUserType(Permissions.ADMIN);
        }
    }
}