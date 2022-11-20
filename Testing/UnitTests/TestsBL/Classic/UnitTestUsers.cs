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

    [AllureXunit(DisplayName = "GetUserByIdUncorrect")]
    public void TestGetUserByIdUncorrect()
    {
        // Act-Assert
        Assert.Throws<BL.UserNotFoundException>(()=> _fixture.Facade.GetUserById(5));
    }

    [AllureXunit(DisplayName = "AddUserUncorrect")]
    public void TestAddUserUncorrect()
    {
        // Arrange
        var user = UserObjectMother.WithoutSurnameUser().Build();

        // Act-Assert
        Assert.Throws<BL.UserAddException>(()=> _fixture.Facade.AddUser(user));
    }

    [AllureXunit(DisplayName = "UpdateUserUncorrect")]
    public void TestUpdateUserUncorrect()
    {
        // Arrange
        var userUpd = UserObjectMother.WithoutLoginUser().Build();

        // Act-Assert
        Assert.Throws<BL.UserUpdateException>(()=> _fixture.Facade.UpdateUser(4, userUpd));
    }

    [AllureXunit(DisplayName = "BlockUserUncorrect")]
    public void TestBlockUserUncorrect()
    {
        // Act-Assert
        Assert.Throws<BL.UserBlockException>(()=> _fixture.Facade.BlockUser(10));
    }
}