namespace AndreyAkaSkif.ServiceResult.BusinessResults;

/// <summary>
/// Ресурс удален
/// </summary>
/// <typeparam name="T">Тип возвращаемого ресурса</typeparam>
/// <remarks>
/// По назначению соответствует HTTP status code 204
/// </remarks>
public sealed class NoContentResult<T> : SuccessResult<T>
{
    public NoContentResult() : base()
    {
    }
}

/// <summary>
/// Ресурс удален
/// </summary>
/// <remarks>
/// По назначению соответствует HTTP status code 204
/// </remarks>
public sealed class NoContentResult : SuccessResult
{
    public NoContentResult() : base()
    {
    }
}
