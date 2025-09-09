namespace AndreyAkaSkif.ServiceResult.Implementations;

/// <summary>
/// Сущность удалена
/// </summary>
/// <typeparam name="T">Тип возвращаемого объекта</typeparam>
/// <remarks>
/// По назначению соответствует HTTP status code 204
/// </remarks>
public sealed class NoContentResult<T> : Result<T>
{
    public override bool IsOk => true;
}
