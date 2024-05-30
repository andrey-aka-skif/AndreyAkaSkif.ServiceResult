namespace AndreyAkaSkif.ServiceResult.Implementations;

/// <summary>
/// Сущность создана
/// </summary>
/// <typeparam name="T">Тип возвращаемого объекта</typeparam>
/// <remarks>
/// По назначению соответствует HTTP status code 201
/// </remarks>
public sealed class CreatedResult<T> : Result<T>
{
    public CreatedResult(T data)
    {
        Data = data;
    }

    public override bool IsOk => true;

    public override T Data { get; }
}
