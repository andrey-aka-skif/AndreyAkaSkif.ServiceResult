namespace AndreyAkaSkif.ServiceResult.Abstractions;

/// <summary>
/// Базовый класс результата
/// </summary>
/// <typeparam name="T">Тип возвращаемого ресурса</typeparam>
public abstract class Result<T>
{
    /// <summary>
    /// Результат успешен
    /// </summary>
    public bool IsOk { get; protected set; }

    /// <summary>
    /// Резельтат неуспешен
    /// </summary>
    public bool IsFailure => !IsOk;

    /// <summary>
    /// Сообщение об ошибке
    /// </summary>
    public string? Error { get; protected set; }

    /// <summary>
    /// Возвращаемый ресурс
    /// </summary>
    public T? Data { get; protected set; }
}


/// <summary>
/// Базовый класс результата
/// </summary>
public abstract class Result
{
    /// <summary>
    /// Результат успешен
    /// </summary>
    public bool IsOk { get; protected set; }

    /// <summary>
    /// Резельтат неуспешен
    /// </summary>
    public bool IsFailure => !IsOk;

    /// <summary>
    /// Сообщение об ошибке
    /// </summary>
    public string? Error { get; protected set; }
}
