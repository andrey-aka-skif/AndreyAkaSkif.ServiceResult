namespace AndreyAkaSkif.ServiceResult.Implementations;

/// <summary>
/// Сущность не найденв
/// </summary>
/// <typeparam name="T">Тип возвращаемого объекта</typeparam>
/// <remarks>
/// По назначению соответствует HTTP status code 404
/// </remarks>
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
