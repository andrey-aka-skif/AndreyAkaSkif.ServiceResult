namespace AndreyAkaSkif.ServiceResult.Implementations;

/// <summary>
/// Выполнено
/// </summary>
/// <typeparam name="T">Тип возвращаемого объекта</typeparam>
/// <remarks>
/// По назначению соответствует HTTP status code 200
/// </remarks>
public sealed class SuccessResult<T> : Result<T>
{
    public SuccessResult(T data)
    {
        Data = data;
    }

    public override bool IsOk => true;

    public override T Data { get; }
}
