using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.EntityFrameworkCore;
// using EntityFrameworkCoreMock;

using Xunit;
using Xunit.Abstractions;
using Moq;

using DB;
using BL;

using UnitTests.ObjectMothers;

namespace UnitTests.TestsDB;

[Collection("DBCollection")]
public class UnitTestUsers: IDisposable
{
    private DBFixture _fixture;

    public UnitTestUsers(DBFixture fixture)
    {
        _fixture = fixture;
    }

    public void Dispose() {}

    [Fact]
    public void TestGetUsers()
    {
        // Act
        List<BL.User> users = _fixture.usersRep.GetUsers();

        // Assert
        Assert.Equal(_fixture.context.Users.Count(), users.Count);
    }

    [Fact]
    public void TestGetUserByIdCorrect()
    {
        // Act
        BL.User user = _fixture.usersRep.GetUserById(1);

        // Assert
        Assert.NotNull(user);
    }

    [Fact]
    public void TestGetUserByIdUncorrect()
    {
        // Act-Assert
        Assert.Throws<DB.UserNotFoundException>(()=> _fixture.usersRep.GetUserById(5));
    }

    [Fact]
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

    [Fact]
    public void TestAddUserUncorrect()
    {
        // Arrange
        var user = UserObjectMother.WithoutSurnameUser().Build();

        // Act-Assert
        Assert.Throws<DB.UsersValidatorFailException>(()=> _fixture.usersRep.AddUser(user));
    }

    [Fact]
    public void TestUpdateUserCorrect()
    {
        // Arrange
        BL.User userUpd = UserObjectMother.UpdUser().Build();

        // Act
        _fixture.usersRep.UpdateUser(1, userUpd);

        var userNew = _fixture.usersRep.GetUserById(1);

        // Assert
        Assert.Equal("Name1", userNew.Name);
        Assert.Equal("Surname1", userNew.Surname);
        Assert.Equal("LoginNew", userNew.Login);
        Assert.Equal("Password1", userNew.Password);
    }

    [Fact]
    public void TestUpdateUserUncorrect()
    {
        // Arrange
        var userUpd = UserObjectMother.WithoutLoginUser().Build();

        // Act-Assert
        Assert.Throws<DB.UsersValidatorFailException>(()=> _fixture.usersRep.UpdateUser(4, userUpd));
    }

    [Fact]
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

    [Fact]
    public void TestBlockUserUncorrect()
    {
        // Act-Assert
        Assert.Throws<DB.UserNotFoundException>(()=> _fixture.usersRep.BlockUser(5));
    }
}