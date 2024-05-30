namespace AndreyAkaSkif.ServiceResult.Abstractions;

/// <summary>
/// Базовый класс результата
/// </summary>
/// <typeparam name="T">Тип возвращаемого объекта</typeparam>
public abstract class Result<T>
{
    public virtual bool IsOk { get; } = false;
    public bool IsFailure => !IsOk;
    public virtual string Error { get; } = string.Empty;
    public virtual T? Data { get; } = default;
}

