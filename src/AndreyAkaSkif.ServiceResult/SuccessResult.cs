namespace AndreyAkaSkif.ServiceResult;

/// <summary>
/// Выполнено
/// </summary>
/// <typeparam name="T">Тип возвращаемого ресурса</typeparam>
/// <remarks>
/// По назначению соответствует HTTP status code 200
/// </remarks>
public class SuccessResult<T> : Result<T>
{
    public SuccessResult()
    {
        IsOk = true;
    }

    public SuccessResult(T data)
    {
        Data = data;
        IsOk = true;
    }
}
