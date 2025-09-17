namespace AndreyAkaSkif.ServiceResult.Abstractions;

/// <summary>
/// Базовый класс результата
/// </summary>
/// <typeparam name="T">Тип возвращаемого ресурса</typeparam>
public abstract class Result<T>
{
    public bool IsOk { get; protected set; } = false;
    public bool IsFailure => !IsOk;
    public string? Error { get; protected set; } = default;
    public T? Data { get; protected set; } = default;
}
