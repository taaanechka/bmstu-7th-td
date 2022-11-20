using UnitTests.Builders;
using BL;

namespace UnitTests.ObjectMothers
{
    public class UserObjectMother
    {
        public static UserBLBuilder DefaultUser1() 
        {
            return new UserBLBuilder()
                        .WithName("Name1")
                        .WithSurname("Surname1")
                        .WithLogin("Login1")
                        .WithPassword("Password1")
                        .WithUserType(Permissions.EMPLOYEE);
        }

        public static UserBLBuilder DefaultUser2() 
        {
            return new UserBLBuilder()
                        .WithName("Name2")
                        .WithSurname("Surname2")
                        .WithLogin("Login2")
                        .WithPassword("Password2")
                        .WithUserType(Permissions.EMPLOYEE);
        }

        public static UserBLBuilder DefaultUser3() 
        {
            return new UserBLBuilder()
                        .WithName("Name3")
                        .WithSurname("Surname3")
                        .WithLogin("Login3")
                        .WithPassword("Password3")
                        .WithUserType(Permissions.EMPLOYEE);
        }

        public static UserBLBuilder UpdUser() 
        {
            return new UserBLBuilder()
                        .WithName("Name1")
                        .WithSurname("Surname1")
                        .WithLogin("LoginNew")
                        .WithPassword("Password1")
                        .WithUserType(Permissions.EMPLOYEE);
        }

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

        public static UserBLBuilder WithoutNameUser() 
        {
            return new UserBLBuilder()
                        .WithSurname("SurnameEmployee")
                        .WithLogin("LoginEmployee")
                        .WithPassword("123123")
                        .WithUserType(Permissions.EMPLOYEE);
        }

        public static UserBLBuilder WithoutSurnameUser() 
        {
            return new UserBLBuilder()
                        .WithName("NameEmployee")
                        .WithLogin("LoginEmployee")
                        .WithPassword("123123")
                        .WithUserType(Permissions.EMPLOYEE);
        }

        public static UserBLBuilder WithoutLoginUser() 
        {
            return new UserBLBuilder()
                        .WithName("NameEmployee")
                        .WithSurname("SurnameEmployee")
                        .WithPassword("123123")
                        .WithUserType(Permissions.EMPLOYEE);
        }
    }
}