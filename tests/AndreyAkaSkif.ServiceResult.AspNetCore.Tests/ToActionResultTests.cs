using Mvc = Microsoft.AspNetCore.Mvc;

namespace AndreyAkaSkif.ServiceResult.AspNetCore.Tests;

public class ToActionResultTests
{
    [Fact]
    public void Success_MapsTo_200_WithData()
    {
        var result = new SuccessResult<int>(5).ToActionResult();

        var ok = Assert.IsType<Mvc.OkObjectResult>(result);
        Assert.Equal(200, ok.StatusCode);
        Assert.Equal(5, ok.Value);
    }

    [Fact]
    public void Created_MapsTo_201_WithoutLocation()
    {
        var result = new CreatedResult<int>(5).ToActionResult();

        var created = Assert.IsType<Mvc.CreatedAtActionResult>(result);
        Assert.Equal(201, created.StatusCode);
        Assert.Equal(5, created.Value);
        Assert.Null(created.ActionName);
    }

    [Fact]
    public void Created_WithLocation_FillsRoute()
    {
        var result = new CreatedResult<int>(5)
            .ToActionResult(new ResourceLocationInfo("GetById", "Items", new { id = 5 }));

        var created = Assert.IsType<Mvc.CreatedAtActionResult>(result);
        Assert.Equal("GetById", created.ActionName);
        Assert.Equal("Items", created.ControllerName);
        Assert.Equal(5, created.Value);
    }

    [Fact]
    public void Updated_MapsTo_200()
    {
        var result = new UpdatedResult<int>(5).ToActionResult();

        Assert.Equal(200, Assert.IsType<Mvc.OkObjectResult>(result).StatusCode);
    }

    [Fact]
    public void NoContent_MapsTo_204()
    {
        var result = new NoContentResult<int>().ToActionResult();

        Assert.Equal(204, Assert.IsType<Mvc.NoContentResult>(result).StatusCode);
    }

    [Fact]
    public void NotFound_MapsTo_404_WithErrorMessage()
    {
        var result = new NotFoundResult<int>().ToActionResult();

        var notFound = Assert.IsType<Mvc.NotFoundObjectResult>(result);
        Assert.Equal(404, notFound.StatusCode);
        Assert.Equal("Ресурс не найден", Assert.IsType<ErrorMessage>(notFound.Value).Title);
    }

    [Fact]
    public void Conflict_MapsTo_409()
    {
        var result = new ConflictResult<int>().ToActionResult();

        Assert.Equal(409, Assert.IsType<Mvc.ConflictObjectResult>(result).StatusCode);
    }

    [Fact]
    public void Invalid_MapsTo_400_WithErrorMessage()
    {
        var result = new InvalidResult<int>("boom").ToActionResult();

        var bad = Assert.IsType<Mvc.BadRequestObjectResult>(result);
        Assert.Equal(400, bad.StatusCode);
        Assert.Equal("boom", Assert.IsType<ErrorMessage>(bad.Value).Title);
    }

    [Fact]
    public void Untyped_NoContent_MapsTo_204()
    {
        var result = new NoContentResult().ToActionResult();

        Assert.Equal(204, Assert.IsType<Mvc.NoContentResult>(result).StatusCode);
    }

    [Fact]
    public void Untyped_Invalid_MapsTo_400()
    {
        var result = new InvalidResult("x").ToActionResult();

        Assert.Equal(400, Assert.IsType<Mvc.BadRequestObjectResult>(result).StatusCode);
    }

    [Fact]
    public void Untyped_Created_WithLocation_FillsRoute()
    {
        var result = new CreatedResult()
            .ToActionResult(new ResourceLocationInfo("GetById", "Items", new { id = 1 }));

        Assert.Equal("GetById", Assert.IsType<Mvc.CreatedAtActionResult>(result).ActionName);
    }
}
