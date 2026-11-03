namespace AndreyAkaSkif.ServiceResult.CrudResults;

/// <summary>
/// Нет содержимого
/// </summary>
/// <typeparam name="T">Тип возвращаемого ресурса</typeparam>
/// <remarks>
/// По назначению соответствует HTTP status code 204
/// </remarks>
public sealed class NoContentResult<T> : SuccessResult<T>;

/// <summary>
/// Нет содержимого
/// </summary>
/// <remarks>
/// По назначению соответствует HTTP status code 204
/// </remarks>
public sealed class NoContentResult : SuccessResult;
