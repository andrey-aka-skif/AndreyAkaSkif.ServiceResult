namespace AndreyAkaSkif.ServiceResult.CrudResults;

/// <summary>
/// Ресурс создан
/// </summary>
/// <typeparam name="T">Тип возвращаемого ресурса</typeparam>
/// <remarks>
/// По назначению соответствует HTTP status code 201
/// </remarks>
public sealed class CreatedResult<T>(T data) : SuccessResult<T>(data);


/// <summary>
/// Ресурс создан
/// </summary>
/// <remarks>
/// По назначению соответствует HTTP status code 201
/// </remarks>
public sealed class CreatedResult : SuccessResult;
