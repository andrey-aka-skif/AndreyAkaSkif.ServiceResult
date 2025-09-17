namespace AndreyAkaSkif.ServiceResult;

/// <summary>
/// Не удалось выполнить
/// </summary>
/// <typeparam name="T">Тип возвращаемого ресурса</typeparam>
public class InvalidResult<T> : Result<T>
{
    private const string DEFAULT_ERROR_MESSAGE = "Не удалось выполнить операцию";

    public InvalidResult() : this(DEFAULT_ERROR_MESSAGE) { }

    public InvalidResult(string error)
    {
        if (!string.IsNullOrWhiteSpace(error))
            Error = error;
        else
            Error = DEFAULT_ERROR_MESSAGE;
    }
}
