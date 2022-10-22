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
[AllureSuite("Models Tests")]
[Collection("DBCollection")]
public class UnitTestModels: IDisposable
{
    private DBFixture _fixture;

    public UnitTestModels(DBFixture fixture)
    {
        _fixture = fixture;
    }

    public void Dispose() {}

    [AllureXunit(DisplayName = "GetModels")]
    public void TestGetModels()
    {
        // Act
        List<BL.Model> Models = _fixture.modelsRep.GetModels();

        // Assert
        Assert.Equal(_fixture.context.Models.Count(), Models.Count);
    }

    [AllureXunit(DisplayName = "GetModelByIdCorrect")]
    public void TestGetModelByIdCorrect()
    {
        // Act
        BL.Model Model = _fixture.modelsRep.GetModelById(1);

        // Assert
        Assert.NotNull(Model);
    }

    [AllureXunit(DisplayName = "GetModelByIdUncorrect")]
    public void TestGetModelByIdUncorrect()
    {
        // Act-Assert
        Assert.Throws<DB.ModelNotFoundException>(()=> _fixture.modelsRep.GetModelById(5));
    }

    [AllureXunit(DisplayName = "AddModelCorrect")]
    public void TestAddModelCorrect()
    {
        // Arrange
        var Model = ModelObjectMother.DefaultModel4().Build();

        var count = _fixture.context.Models.Count() + 1;

        // Act
        _fixture.modelsRep.AddModel(Model);

        // Assert
        Assert.Equal(count, _fixture.context.Models.Count());
    }

    [AllureXunit(DisplayName = "AddModelUncorrect")]
    public void TestAddModelUncorrect()
    {
        // Arrange
        var Model = ModelObjectMother.WithoutNameModel().Build();

        // Act-Assert
        Assert.Throws<DB.ModelsValidatorFailException>(()=> _fixture.modelsRep.AddModel(Model));
    }

    [AllureXunit(DisplayName = "UpdateModelCorrect")]
    public void TestUpdateModelCorrect()
    {
        // Arrange
        var ModelUpd = ModelObjectMother.UpdDefaultModel().Build();

        // Act
        _fixture.modelsRep.UpdateModel(1, ModelUpd);

        var ModelNew = _fixture.modelsRep.GetModelById(1);

        // Assert
        Assert.Equal(ModelUpd.BrandId, ModelNew.BrandId);
        Assert.Equal(ModelUpd.Name, ModelNew.Name);
    }

    [AllureXunit(DisplayName = "UpdateModelUncorrect")]
    public void TestUpdateModelUncorrect()
    {
        // Arrange
        var ModelUpd = ModelObjectMother.WithoutBrandIdModel().Build();

        // Act-Assert
        Assert.Throws<DB.ModelsValidatorFailException>(()=> _fixture.modelsRep.UpdateModel(2, ModelUpd));
    }

    [AllureXunit(DisplayName = "DeleteModelCorrect")]
    public void TestDeleteModelCorrect()
    {
        // Arrange
        var count = _fixture.context.Models.Count() - 1;

        // Act
        _fixture.modelsRep.DeleteModel(3);

        // Assert
        Assert.Equal(count, _fixture.context.Models.Count());
    }

    [AllureXunit(DisplayName = "DeleteModelUncorrect")]
    public void TestDeleteModelUncorrect()
    {
        // Act-Assert
        Assert.Throws<DB.ModelNotFoundException>(()=> _fixture.modelsRep.DeleteModel(5));
    }
}