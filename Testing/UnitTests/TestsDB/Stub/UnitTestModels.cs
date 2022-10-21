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
public class UnitTestModels: IDisposable
{
    private DBFixture _fixture;

    public UnitTestModels(DBFixture fixture)
    {
        _fixture = fixture;
    }

    public void Dispose() {}

    [Fact]
    public void TestGetModels()
    {
        // Act
        List<BL.Model> Models = _fixture.modelsRep.GetModels();

        // Assert
        Assert.Equal(_fixture.context.Models.Count(), Models.Count);
    }

    [Fact]
    public void TestGetModelByIdCorrect()
    {
        // Act
        BL.Model Model = _fixture.modelsRep.GetModelById(1);

        // Assert
        Assert.NotNull(Model);
    }

    [Fact]
    public void TestGetModelByIdUncorrect()
    {
        // Act-Assert
        Assert.Throws<DB.ModelNotFoundException>(()=> _fixture.modelsRep.GetModelById(5));
    }

    [Fact]
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

    [Fact]
    public void TestAddModelUncorrect()
    {
        // Arrange
        var Model = ModelObjectMother.WithoutNameModel().Build();

        // Act-Assert
        Assert.Throws<DB.ModelsValidatorFailException>(()=> _fixture.modelsRep.AddModel(Model));
    }

    [Fact]
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

    [Fact]
    public void TestUpdateModelUncorrect()
    {
        // Arrange
        var ModelUpd = ModelObjectMother.WithoutBrandIdModel().Build();

        // Act-Assert
        Assert.Throws<DB.ModelsValidatorFailException>(()=> _fixture.modelsRep.UpdateModel(2, ModelUpd));
    }

    [Fact]
    public void TestDeleteModelCorrect()
    {
        // Arrange
        var count = _fixture.context.Models.Count() - 1;

        // Act
        _fixture.modelsRep.DeleteModel(3);

        // Assert
        Assert.Equal(count, _fixture.context.Models.Count());
    }

    [Fact]
    public void TestDeleteModelUncorrect()
    {
        // Act-Assert
        Assert.Throws<DB.ModelNotFoundException>(()=> _fixture.modelsRep.DeleteModel(5));
    }
}