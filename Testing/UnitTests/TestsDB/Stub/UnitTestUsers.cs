using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.EntityFrameworkCore;
// using EntityFrameworkCoreMock;

using Xunit;
using Xunit.Abstractions;
using Moq;
using Allure.Xunit;
using Allure.Xunit.Attributes;

using DB;
using BL;

using UnitTests.ObjectMothers;

namespace UnitTests.TestsDB;

[AllureParentSuite("DBTests.Stub")]
[AllureSuite("Users Tests")]
[Collection("DBCollection")]
public class UnitTestUsers: IDisposable
{
    private DBFixture _fixture;

    public UnitTestUsers(DBFixture fixture)
    {
        _fixture = fixture;
    }

    public void Dispose() {}

    [AllureXunit(DisplayName = "GetUsers")]
    public void TestGetUsers()
    {
        // Act
        List<BL.User> users = _fixture.usersRep.GetUsers();

        // Assert
        Assert.Equal(_fixture.context.Users.Count(), users.Count);
    }

    [AllureXunit(DisplayName = "GetUserByIdCorrect")]
    public void TestGetUserByIdCorrect()
    {
        // Act
        BL.User user = _fixture.usersRep.GetUserById(1);

        // Assert
        Assert.NotNull(user);
    }

    [AllureXunit(DisplayName = "GetUserByIdUncorrect")]
    public void TestGetUserByIdUncorrect()
    {
        // Act-Assert
        Assert.Throws<DB.UserNotFoundException>(()=> _fixture.usersRep.GetUserById(5));
    }

    [AllureXunit(DisplayName = "AddUserCorrect")]
    public void TestAddUserCorrect()
    {
        // Arrange
        var user = UserObjectMother.DefaultUser().Build();

        var count = _fixture.context.Users.Count() + 1;

        // Act
        _fixture.usersRep.AddUser(user);

        // Assert
        Assert.Equal(count, _fixture.context.Users.Count());
    }

    [AllureXunit(DisplayName = "AddUserUncorrect")]
    public void TestAddUserUncorrect()
    {
        // Arrange
        var user = UserObjectMother.WithoutSurnameUser().Build();

        // Act-Assert
        Assert.Throws<DB.UsersValidatorFailException>(()=> _fixture.usersRep.AddUser(user));
    }

    [AllureXunit(DisplayName = "UpdateUserCorrect")]
    public void TestUpdateUserCorrect()
    {
        // Arrange
        BL.User userUpd = UserObjectMother.UpdUser().Build();

        // Act
        _fixture.usersRep.UpdateUser(1, userUpd);

        var userNew = _fixture.usersRep.GetUserById(1);

        // Assert
        Assert.Equal(userUpd.Name, userNew.Name);
        Assert.Equal(userUpd.Surname, userNew.Surname);
        Assert.Equal(userUpd.Login, userNew.Login);
        Assert.Equal(userUpd.Password, userNew.Password);
    }

    [AllureXunit(DisplayName = "UpdateUserUncorrect")]
    public void TestUpdateUserUncorrect()
    {
        // Arrange
        var userUpd = UserObjectMother.WithoutLoginUser().Build();

        // Act-Assert
        Assert.Throws<DB.UsersValidatorFailException>(()=> _fixture.usersRep.UpdateUser(4, userUpd));
    }

    [AllureXunit(DisplayName = "BlockUserCorrect")]
    public void TestBlockUserCorrect()
    {
        // Arrange
        var count = _fixture.context.Users.Count();

        // Act
        _fixture.usersRep.BlockUser(3);

        var user = _fixture.usersRep.GetUserById(3);

        // Assert
        Assert.Equal((int)user.UserType, (int)BL.Permissions.UNAUTHORIZED);
        Assert.Equal(count, _fixture.context.Users.Count());
    }

    [AllureXunit(DisplayName = "BlockUserUncorrect")]
    public void TestBlockUserUncorrect()
    {
        // Act-Assert
        Assert.Throws<DB.UserNotFoundException>(()=> _fixture.usersRep.BlockUser(5));
    }
}