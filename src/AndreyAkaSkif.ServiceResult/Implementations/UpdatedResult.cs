namespace AndreyAkaSkif.ServiceResult.Implementations;

/// <summary>
/// Сущность обновлена
/// </summary>
/// <typeparam name="T">Тип возвращаемого объекта</typeparam>
/// <remarks>
/// По назначению соответствует HTTP status code 200
/// </remarks>
public sealed class UpdatedResult<T> : Result<T>
{
    public UpdatedResult(T data)
    {
        Data = data;
    }

    public override bool IsOk => true;

    public override T Data { get; }
}
