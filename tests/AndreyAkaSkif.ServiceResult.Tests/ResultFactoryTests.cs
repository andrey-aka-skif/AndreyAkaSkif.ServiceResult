namespace AndreyAkaSkif.ServiceResult.Tests;

public class ResultFactoryTests
{
    private const string DefaultInvalidMessage = "Не удалось выполнить операцию";
    private const string DefaultNotFoundMessage = "Ресурс не найден";

    [Fact]
    public void Generic_CreateSuccessResult_ReturnsSuccessWithData()
    {
        var result = ResultFactory<int>.CreateSuccessResult(7);

        Assert.IsType<SuccessResult<int>>(result);
        Assert.True(result.IsOk);
        Assert.Equal(7, result.Data);
    }

    [Fact]
    public void Generic_CreateInvalidResult_Null_UsesDefaultMessage()
    {
        var result = ResultFactory<int>.CreateInvalidResult(null);

        Assert.IsType<InvalidResult<int>>(result);
        Assert.True(result.IsFailure);
        Assert.Equal(DefaultInvalidMessage, result.Error);
    }

    [Fact]
    public void Generic_CreateInvalidResult_CustomError_IsPreserved()
    {
        var result = ResultFactory<int>.CreateInvalidResult("bad");

        Assert.Equal("bad", result.Error);
    }

    [Fact]
    public void NonGeneric_CreateSuccessResult_IsOk()
    {
        var result = ResultFactory.CreateSuccessResult();

        Assert.IsType<SuccessResult>(result);
        Assert.True(result.IsOk);
    }

    [Fact]
    public void NonGeneric_CreateNotFoundResult_Null_UsesDefaultMessage()
    {
        var result = ResultFactory.CreateNotFoundResult(null);

        Assert.IsType<NotFoundResult>(result);
        Assert.True(result.IsFailure);
        Assert.Equal(DefaultNotFoundMessage, result.Error);
    }
}
