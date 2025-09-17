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
    public bool IsOk { get; protected set; } = false;

    /// <summary>
    /// Резельтат неуспешен
    /// </summary>
    public bool IsFailure => !IsOk;

    /// <summary>
    /// Сообщение об ошибке
    /// </summary>
    public string? Error { get; protected set; } = default;

    /// <summary>
    /// Возвращаемый ресурс
    /// </summary>
    public T? Data { get; protected set; } = default;
}


/// <summary>
/// Базовый класс результата
/// </summary>
public abstract class Result
{
    /// <summary>
    /// Результат успешен
    /// </summary>
    public bool IsOk { get; protected set; } = false;

    /// <summary>
    /// Резельтат неуспешен
    /// </summary>
    public bool IsFailure => !IsOk;

    /// <summary>
    /// Сообщение об ошибке
    /// </summary>
    public string? Error { get; protected set; } = default;
}
