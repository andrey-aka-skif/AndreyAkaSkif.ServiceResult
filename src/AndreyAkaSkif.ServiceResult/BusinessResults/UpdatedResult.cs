namespace AndreyAkaSkif.ServiceResult.BusinessResults;

/// <summary>
/// Ресурс обновлен
/// </summary>
/// <typeparam name="T">Тип возвращаемого ресурса</typeparam>
/// <remarks>
/// По назначению соответствует HTTP status code 200
/// </remarks>
public sealed class UpdatedResult<T> : SuccessResult<T>
{
    public UpdatedResult(T data) : base(data) { }
}

/// <summary>
/// Ресурс обновлен
/// </summary>
/// <remarks>
/// По назначению соответствует HTTP status code 200
/// </remarks>
public sealed class UpdatedResult : SuccessResult
{
    public UpdatedResult() : base() { }
}
