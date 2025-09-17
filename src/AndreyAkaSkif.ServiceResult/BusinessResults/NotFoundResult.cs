namespace AndreyAkaSkif.ServiceResult.BusinessResults;

/// <summary>
/// Ресурс не найден
/// </summary>
/// <typeparam name="T">Тип возвращаемого ресурса</typeparam>
/// <remarks>
/// По назначению соответствует HTTP status code 404
/// </remarks>
public sealed class NotFoundResult<T> : InvalidResult<T>
{
    private const string DEFAULT_ERROR_MESSAGE = "Ресурс не найден";

    public NotFoundResult() : base(DEFAULT_ERROR_MESSAGE) { }

    public NotFoundResult(string error) : base(error) { }
}
