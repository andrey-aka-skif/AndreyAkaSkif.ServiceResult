namespace AndreyAkaSkif.ServiceResult.Implementations;

/// <summary>
/// Конфликт при создании сущности
/// </summary>
/// <typeparam name="T">Тип возвращаемого объекта</typeparam>
/// <remarks>
/// По назначению соответствует HTTP status code 409
/// </remarks>
public sealed class ConflictResult<T> : Result<T>
{
    private const string DEFAULT_ERROR_MESSAGE = "Ресурс уже существует";

    public ConflictResult() { }

    public ConflictResult(string error)
    {
        if (!string.IsNullOrWhiteSpace(error))
            Error = error;
    }

    public override string Error { get; } = DEFAULT_ERROR_MESSAGE;
}
