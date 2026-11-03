namespace AndreyAkaSkif.ServiceResult.Tests;

public class InvalidResultTests
{
    private const string DefaultInvalidMessage = "Не удалось выполнить операцию";
    private const string DefaultNotFoundMessage = "Ресурс не найден";
    private const string DefaultConflictMessage = "Ресурс уже существует";

    [Fact]
    public void InvalidResult_Default_IsFailure_WithDefaultMessage()
    {
        var result = new InvalidResult<string>();

        Assert.False(result.IsOk);
        Assert.True(result.IsFailure);
        Assert.Equal(DefaultInvalidMessage, result.Error);
        Assert.Null(result.Data);
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public void InvalidResult_WhitespaceError_FallsBackToDefault(string error)
    {
        var result = new InvalidResult<int>(error);

        Assert.Equal(DefaultInvalidMessage, result.Error);
    }

    [Fact]
    public void InvalidResult_CustomError_IsPreserved()
    {
        var result = new InvalidResult<int>("boom");

        Assert.Equal("boom", result.Error);
        Assert.True(result.IsFailure);
    }

    [Fact]
    public void NotFoundResult_Default_Message_And_IsInvalidResult()
    {
        var result = new NotFoundResult<int>();

        Assert.IsType<InvalidResult<int>>(result, exactMatch: false);
        Assert.True(result.IsFailure);
        Assert.Equal(DefaultNotFoundMessage, result.Error);
    }

    [Fact]
    public void ConflictResult_Default_Message_And_IsInvalidResult()
    {
        var result = new ConflictResult<int>();

        Assert.IsType<InvalidResult<int>>(result, exactMatch: false);
        Assert.True(result.IsFailure);
        Assert.Equal(DefaultConflictMessage, result.Error);
    }

    [Fact]
    public void NonGeneric_NotFoundResult_IsFailure_WithDefaultMessage()
    {
        var result = new NotFoundResult();

        Assert.True(result.IsFailure);
        Assert.Equal(DefaultNotFoundMessage, result.Error);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void NotFoundResult_NullOrWhitespaceError_FallsBackToNotFoundMessage(string? error)
    {
        var result = new NotFoundResult<int>(error);

        Assert.Equal(DefaultNotFoundMessage, result.Error);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void NonGeneric_NotFoundResult_NullOrWhitespaceError_FallsBackToNotFoundMessage(string? error)
    {
        var result = new NotFoundResult(error);

        Assert.Equal(DefaultNotFoundMessage, result.Error);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void ConflictResult_NullOrWhitespaceError_FallsBackToConflictMessage(string? error)
    {
        var result = new ConflictResult<int>(error);

        Assert.Equal(DefaultConflictMessage, result.Error);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void NonGeneric_ConflictResult_NullOrWhitespaceError_FallsBackToConflictMessage(string? error)
    {
        var result = new ConflictResult(error);

        Assert.Equal(DefaultConflictMessage, result.Error);
    }

    [Fact]
    public void NotFoundResult_TakesErrorOfAnotherResult_WithoutNullForgiving()
    {
        var other = new InvalidResult<int>("boom");

        var result = new NotFoundResult<int>(other.Error);

        Assert.Equal("boom", result.Error);
    }
}
