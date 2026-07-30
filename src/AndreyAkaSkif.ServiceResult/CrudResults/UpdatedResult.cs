namespace AndreyAkaSkif.ServiceResult.CrudResults;

/// <summary>
/// Ресурс обновлен
/// </summary>
/// <typeparam name="T">Тип возвращаемого ресурса</typeparam>
/// <remarks>
/// По назначению соответствует HTTP status code 200
/// </remarks>
public sealed class UpdatedResult<T>(T data) : SuccessResult<T>(data);

/// <summary>
/// Ресурс обновлен
/// </summary>
/// <remarks>
/// По назначению соответствует HTTP status code 200
/// </remarks>
public sealed class UpdatedResult : SuccessResult;
