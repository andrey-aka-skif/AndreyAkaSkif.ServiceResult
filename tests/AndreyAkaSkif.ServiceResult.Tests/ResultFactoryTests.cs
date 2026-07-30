namespace AndreyAkaSkif.ServiceResult.Tests;

public class ResultFactoryTests
{
    private const string DefaultInvalidMessage = "Не удалось выполнить операцию";
    private const string DefaultNotFoundMessage = "Ресурс не найден";

    [Fact]
    public void Generic_Success_ReturnsSuccessWithData()
    {
        var result = ResultFactory.Success(7);

        Assert.IsType<SuccessResult<int>>(result);
        Assert.True(result.IsOk);
        Assert.Equal(7, result.Data);
    }

    [Fact]
    public void Generic_Invalid_Null_UsesDefaultMessage()
    {
        var result = ResultFactory.Invalid<int>(null);

        Assert.IsType<InvalidResult<int>>(result);
        Assert.True(result.IsFailure);
        Assert.Equal(DefaultInvalidMessage, result.Error);
    }

    [Fact]
    public void Generic_Invalid_CustomError_IsPreserved()
    {
        var result = ResultFactory.Invalid<int>("bad");

        Assert.Equal("bad", result.Error);
    }

    [Fact]
    public void NonGeneric_Success_IsOk()
    {
        var result = ResultFactory.Success();

        Assert.IsType<SuccessResult>(result);
        Assert.True(result.IsOk);
    }

    [Fact]
    public void NonGeneric_NotFound_Null_UsesDefaultMessage()
    {
        var result = ResultFactory.NotFound(null);

        Assert.IsType<NotFoundResult>(result);
        Assert.True(result.IsFailure);
        Assert.Equal(DefaultNotFoundMessage, result.Error);
    }
}
