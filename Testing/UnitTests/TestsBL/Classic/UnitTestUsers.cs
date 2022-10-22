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

namespace UnitTests.TestsBL.Classic;

[AllureParentSuite("BLTests.Classic")]
[AllureSuite("Users Tests")]
[Collection("BLCollection")]
public class UnitTestUsers: IDisposable
{
    private BLFixture _fixture;

    public UnitTestUsers(BLFixture fixture)
    {
        _fixture = fixture;
    }

    public void Dispose() {}

    [AllureXunit(DisplayName = "GetUsers")]
    public void TestGetUsers()
    {
        // Act
        List<BL.User> users = _fixture.Facade.GetUsers();

        // Assert
        Assert.Equal(_fixture.Context.Users.Count(), users.Count);
    }

    // [AllureXunit(DisplayName = "GetUserByIdCorrect")]
    // public void TestGetUserByIdCorrect()
    // {
    //     // Act
    //     BL.User user = _fixture.Facade.GetUserById(1);

    //     // Assert
    //     Assert.NotNull(user);
    // }

    [AllureXunit(DisplayName = "GetUserByIdUncorrect")]
    public void TestGetUserByIdUncorrect()
    {
        // Act-Assert
        Assert.Throws<BL.UserNotFoundException>(()=> _fixture.Facade.GetUserById(5));
    }

    // [AllureXunit(DisplayName = "AddUserCorrect")]
    // public void TestAddUserCorrect()
    // {
    //     // Arrange
    //     var user = UserObjectMother.DefaultUser().Build();

    //     var count = _fixture.Context.Users.Count() + 1;

    //     // Act
    //     _fixture.Facade.AddUser(user);

    //     // Assert
    //     Assert.Equal(count, _fixture.Context.Users.Count());
    // }

    [AllureXunit(DisplayName = "AddUserUncorrect")]
    public void TestAddUserUncorrect()
    {
        // Arrange
        var user = UserObjectMother.WithoutSurnameUser().Build();

        // Act-Assert
        Assert.Throws<BL.UserAddException>(()=> _fixture.Facade.AddUser(user));
    }

    // [AllureXunit(DisplayName = "UpdateUserCorrect")]
    // public void TestUpdateUserCorrect()
    // {
    //     // Arrange
    //     BL.User userUpd = UserObjectMother.UpdUser().Build();

    //     // Act
    //     _fixture.Facade.UpdateUser(1, userUpd);

    //     var userNew = _fixture.Facade.GetUserById(1);

    //     // Assert
    //     Assert.Equal(userUpd.Name, userNew.Name);
    //     Assert.Equal(userUpd.Surname, userNew.Surname);
    //     Assert.Equal(userUpd.Login, userNew.Login);
    //     Assert.Equal(userUpd.Password, userNew.Password);
    // }

    [AllureXunit(DisplayName = "UpdateUserUncorrect")]
    public void TestUpdateUserUncorrect()
    {
        // Arrange
        var userUpd = UserObjectMother.WithoutLoginUser().Build();

        // Act-Assert
        Assert.Throws<BL.UserUpdateException>(()=> _fixture.Facade.UpdateUser(4, userUpd));
    }

    // [AllureXunit(DisplayName = "BlockUserCorrect")]
    // public void TestBlockUserCorrect()
    // {
    //     // Arrange
    //     var count = _fixture.Context.Users.Count();

    //     // Act
    //     _fixture.Facade.BlockUser(3);

    //     var user = _fixture.Facade.GetUserById(3);

    //     // Assert
    //     Assert.Equal((int)user.UserType, (int)BL.Permissions.UNAUTHORIZED);
    //     Assert.Equal(count, _fixture.Context.Users.Count());
    // }

    [AllureXunit(DisplayName = "BlockUserUncorrect")]
    public void TestBlockUserUncorrect()
    {
        // Act-Assert
        Assert.Throws<BL.UserBlockException>(()=> _fixture.Facade.BlockUser(10));
    }
}