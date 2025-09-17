namespace AndreyAkaSkif.ServiceResult.BusinessResults;

/// <summary>
/// Конфликт при создании ресурса
/// </summary>
/// <typeparam name="T">Тип возвращаемого ресурса</typeparam>
/// <remarks>
/// По назначению соответствует HTTP status code 409
/// </remarks>
public sealed class ConflictResult<T> : InvalidResult<T>
{
    private const string DEFAULT_ERROR_MESSAGE = "Ресурс уже существует";

    public ConflictResult() : base(DEFAULT_ERROR_MESSAGE) { }

    public ConflictResult(string error) : base(error) { }
}
