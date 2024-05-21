namespace AndreyAkaSkif.ServiceResult.Implementations;

public sealed class NotFoundResult<T> : Result<T>
{
    private const string DEFAULT_ERROR_MESSAGE = "Объект не найден";

    public NotFoundResult() { }

    public NotFoundResult(string error)
    {
        if (!string.IsNullOrWhiteSpace(error))
            Error = error;
    }

    public override string Error { get; } = DEFAULT_ERROR_MESSAGE;
}
