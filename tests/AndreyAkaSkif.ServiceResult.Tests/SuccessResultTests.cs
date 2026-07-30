namespace AndreyAkaSkif.ServiceResult.Tests;

public class SuccessResultTests
{
    [Fact]
    public void SuccessResult_WithData_IsOk_And_ExposesData()
    {
        var result = new SuccessResult<int>(42);

        Assert.True(result.IsOk);
        Assert.False(result.IsFailure);
        Assert.Equal(42, result.Data);
        Assert.Null(result.Error);
    }

    [Fact]
    public void SuccessResult_NonGeneric_IsOk()
    {
        var result = new SuccessResult();

        Assert.True(result.IsOk);
        Assert.False(result.IsFailure);
        Assert.Null(result.Error);
    }

    [Fact]
    public void CreatedResult_IsSuccessResult_And_ExposesData()
    {
        var result = new CreatedResult<string>("id");

        Assert.IsType<SuccessResult<string>>(result, exactMatch: false);
        Assert.True(result.IsOk);
        Assert.Equal("id", result.Data);
    }

    [Fact]
    public void UpdatedResult_IsOk_And_ExposesData()
    {
        var result = new UpdatedResult<string>("v");

        Assert.True(result.IsOk);
        Assert.Equal("v", result.Data);
    }

    [Fact]
    public void NoContentResult_IsOk_WithoutData()
    {
        var result = new NoContentResult<string>();

        Assert.True(result.IsOk);
        Assert.Null(result.Data);
    }
}
