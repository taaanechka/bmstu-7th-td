using System;
using System.Collections.Generic;
using Xunit;
using Moq;

using BL;
using UnitTests.Builders;
using UnitTests.ObjectMothers;

namespace UnitTests.TestsBL;

public class UnitTestsUsers
{
    // private static UnitTests.Entities.User? userEmpty = null;

    public static IEnumerable<object[]> DataForTestGetUserCorrect =>
        new List<object[]>
        {
            new object[] {"Name1", "Surname1", "Login1", "Password1", (BL.Permissions) 3}
        };

    public static IEnumerable<object[]> DataForTestAddUserCorrect =>
        new List<object[]>
        {
            new object[] {"Name1", "Surname1", "Login1", "Password1", (BL.Permissions) 3},
            new object[] {"Name2", "Surname2", "Login2", "Password2", (BL.Permissions) 2}
        };

    public static IEnumerable<object[]> DataForTestUpdateUserCorrect =>
        new List<object[]>
        {
            new object[] {"Name1", "Surname1", "Login1", "Password1", (BL.Permissions) 3, "Login555"},
            new object[] {"Name2", "Surname2", "Login2", "Password2", (BL.Permissions) 2, "Login777"}
        };

    // [Theory]
    // [MemberData(nameof(DataForTestGetUserCorrect))]
    // public void TestGetUsers(string name, string surname, string login, string password, BL.Permissions perm)
    [Fact]
    public void TestGetUsers()
    {
        // Arrange
        var retUsers = new List<BL.User>() {
                        UserObjectMother.DefaultUser().Build(),
                        UserObjectMother.AnalystUser().Build(),
                        UserObjectMother.AdminUser().Build()
            };

        Mock<BL.IUsersRepository> mockUsersRep = new Mock<BL.IUsersRepository>();
        mockUsersRep.Setup(r => r.GetUsers(It.IsAny<int>(), It.IsAny<int>()))
                    .Returns(retUsers);

        BL.IRepositoriesFactory mockRepFactory = Mock.Of<BL.IRepositoriesFactory>(f => 
                                                    f.CreateUsersRepository() == mockUsersRep.Object);
        BL.Facade facade = new BL.Facade(mockRepFactory);

        // Act
        var users = facade.GetUsers();

        // Assert
        Assert.Equal(retUsers.Count, users.Count);
    }

    [Theory]
    [MemberData(nameof(DataForTestGetUserCorrect))]
    public void TestGetUserById(string name, string surname, string login, string password, BL.Permissions perm)
    {
        // Arrange
        var user = new UserBLBuilder()
                            .WithName(name)
                            .WithSurname(surname)
                            .WithLogin(login)
                            .WithPassword(password)
                            .WithUserType(perm)
                            .Build();

        Mock<BL.IUsersRepository> mockUsersRep = new Mock<BL.IUsersRepository>();
        mockUsersRep.Setup(rep => rep.GetUserById(It.IsAny<int>())).Returns(user);

        BL.IRepositoriesFactory mockRepFactory = Mock.Of<BL.IRepositoriesFactory>(f => 
                                                    f.CreateUsersRepository() == mockUsersRep.Object);
        BL.Facade facade = new BL.Facade(mockRepFactory);

        // Act
        BL.User res = facade.GetUserById(1);

        // Assert
        Assert.NotNull(res);
        Assert.Equal(name, res.Name);
        Assert.Equal(surname, res.Surname);
        Assert.Equal(login, res.Login);
        Assert.Equal(password, res.Password);
        Assert.Equal(perm, res.UserType);
    }

    [Theory]
    [MemberData(nameof(DataForTestGetUserCorrect))]
    public void TestGetUserByLogin(string name, string surname, string login, string password, BL.Permissions perm)
    {
        // Arrange
        var user = new UserBLBuilder()
                            .WithName(name)
                            .WithSurname(surname)
                            .WithLogin(login)
                            .WithPassword(password)
                            .WithUserType(perm)
                            .Build();

        Mock<BL.IUsersRepository> mockUsersRep = new Mock<BL.IUsersRepository>();
        mockUsersRep.Setup(rep => rep.GetUserByLogin(It.IsAny<string>())).Returns(user);

        BL.IRepositoriesFactory mockRepFactory = Mock.Of<BL.IRepositoriesFactory>(f => 
                                                    f.CreateUsersRepository() == mockUsersRep.Object);
        BL.Facade facade = new BL.Facade(mockRepFactory);

        // Act
        BL.User res = facade.GetUserByLogin("Login1");

        // Assert
        Assert.NotNull(res);
        Assert.Equal(name, res.Name);
        Assert.Equal(surname, res.Surname);
        Assert.Equal(login, res.Login);
        Assert.Equal(password, res.Password);
        Assert.Equal(perm, res.UserType);
    }

    [Theory]
    [MemberData(nameof(DataForTestAddUserCorrect))]
    public void TestAddUser(string name, string surname, string login, string password, BL.Permissions perm)
    {
        // Arrange
        var user = new UserBLBuilder()
                            .WithName(name)
                            .WithSurname(surname)
                            .WithLogin(login)
                            .WithPassword(password)
                            .WithUserType(perm)
                            .Build();

        Mock<BL.IUsersRepository> mockUsersRep = new Mock<BL.IUsersRepository>();
        mockUsersRep.Setup(rep => rep.AddUser(It.IsAny<BL.User>())).Verifiable();

        BL.IRepositoriesFactory mockRepFactory = Mock.Of<BL.IRepositoriesFactory>(f => 
                                                    f.CreateUsersRepository() == mockUsersRep.Object);
        BL.Facade facade = new BL.Facade(mockRepFactory);

        // Act
        facade.AddUser(user);

        // Assert
        mockUsersRep.Verify(x => x.AddUser(user), Times.Once);
    }

    [Theory]
    [MemberData(nameof(DataForTestUpdateUserCorrect))]
    public void TestUpdateUser(string name, string surname, string login, 
                            string password, BL.Permissions perm, string loginNew)
    {
        // Arrange
        var retUser = new UserBLBuilder()
                            .WithName(name)
                            .WithSurname(surname)
                            .WithLogin(login)
                            .WithPassword(password)
                            .WithUserType(perm)
                            .Build();

        var updUser = new UserBLBuilder()
                            .WithName(name)
                            .WithSurname(surname)
                            .WithLogin(loginNew)
                            .WithPassword(password)
                            .WithUserType(perm)
                            .Build();

        Mock<BL.IUsersRepository> mockUsersRep = new Mock<BL.IUsersRepository>();
        mockUsersRep.Setup(rep => rep.GetUserById(It.IsAny<int>())).Returns(retUser);
        mockUsersRep.Setup(rep => rep.UpdateUser(It.IsAny<int>(), It.IsAny<BL.User>())).Verifiable();

        BL.IRepositoriesFactory mockRepFactory = Mock.Of<BL.IRepositoriesFactory>(f => 
                                                    f.CreateUsersRepository() == mockUsersRep.Object);
        BL.Facade facade = new BL.Facade(mockRepFactory);

        // Act
        facade.UpdateUser(1, updUser);

        // Assert
        mockUsersRep.Verify(x => x.UpdateUser(1, updUser), Times.Once);
    }

    [Fact]
    public void TestBlockUser()
    {
        // RepositoriesFactory
        Mock<BL.IUsersRepository> mockUsersRep = new Mock<BL.IUsersRepository>();
        mockUsersRep.Setup(rep => rep.BlockUser(It.IsAny<int>())).Verifiable();

        BL.IRepositoriesFactory mockRepFactory = Mock.Of<BL.IRepositoriesFactory>(f => 
                                                    f.CreateUsersRepository() == mockUsersRep.Object);
        BL.Facade facade = new BL.Facade(mockRepFactory);

        // Act
        facade.BlockUser(1);

        // Assert
        mockUsersRep.Verify(x => x.BlockUser(1), Times.Once);
    }    
}
