namespace AndreyAkaSkif.ServiceResult.AspNetCore.Tests;

public class ToIResultTests
{
    private static int? StatusOf(IResult result) => (result as IStatusCodeHttpResult)?.StatusCode;

    [Fact]
    public void Success_MapsTo_200_WithData()
    {
        var result = new SuccessResult<int>(5).ToIResult();

        var ok = Assert.IsType<Ok<int>>(result);
        Assert.Equal(200, ok.StatusCode);
        Assert.Equal(5, ok.Value);
    }

    [Fact]
    public void Created_MapsTo_201_WithoutLocation()
    {
        var result = new CreatedResult<int>(5).ToIResult();

        Assert.IsType<Created<int>>(result);
        Assert.Equal(201, StatusOf(result));
    }

    [Fact]
    public void Created_WithUri_SetsLocation()
    {
        var result = new CreatedResult<int>(5).ToIResult("/items/5");

        var created = Assert.IsType<Created<int>>(result);
        Assert.Equal("/items/5", created.Location);
        Assert.Equal(5, created.Value);
    }

    [Fact]
    public void Updated_MapsTo_200()
    {
        var result = new UpdatedResult<int>(5).ToIResult();

        Assert.Equal(200, StatusOf(result));
    }

    [Fact]
    public void NoContent_MapsTo_204()
    {
        var result = new NoContentResult<int>().ToIResult();

        Assert.Equal(204, StatusOf(result));
    }

    [Fact]
    public void NotFound_MapsTo_404()
    {
        var result = new NotFoundResult<int>().ToIResult();

        Assert.IsType<NotFound<ErrorMessage>>(result);
        Assert.Equal(404, StatusOf(result));
    }

    [Fact]
    public void Conflict_MapsTo_409()
    {
        var result = new ConflictResult<int>().ToIResult();

        Assert.Equal(409, StatusOf(result));
    }

    [Fact]
    public void Invalid_MapsTo_400()
    {
        var result = new InvalidResult<int>("boom").ToIResult();

        Assert.IsType<BadRequest<ErrorMessage>>(result);
        Assert.Equal(400, StatusOf(result));
    }

    [Fact]
    public void Untyped_NoContent_MapsTo_204()
    {
        var result = new NoContentResult().ToIResult();

        Assert.Equal(204, StatusOf(result));
    }

    [Fact]
    public void Untyped_Updated_MapsTo_200()
    {
        var result = new UpdatedResult().ToIResult();

        Assert.Equal(200, StatusOf(result));
    }
}
