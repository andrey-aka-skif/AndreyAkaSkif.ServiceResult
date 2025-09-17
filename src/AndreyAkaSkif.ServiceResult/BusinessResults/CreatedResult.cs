namespace AndreyAkaSkif.ServiceResult.BusinessResults;

/// <summary>
/// Ресурс создан
/// </summary>
/// <typeparam name="T">Тип возвращаемого ресурса</typeparam>
/// <remarks>
/// По назначению соответствует HTTP status code 201
/// </remarks>
public sealed class CreatedResult<T> : SuccessResult<T>
{
    public CreatedResult(T data) : base(data) { }
}


/// <summary>
/// Ресурс создан
/// </summary>
/// <remarks>
/// По назначению соответствует HTTP status code 201
/// </remarks>
public sealed class CreatedResult : SuccessResult
{
    public CreatedResult() : base() { }
}
