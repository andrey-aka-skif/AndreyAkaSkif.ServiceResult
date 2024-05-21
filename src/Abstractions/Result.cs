namespace AndreyAkaSkif.ServiceResult.Abstractions;

public abstract class Result<T>
{
    public virtual bool IsOk { get; } = false;
    public bool IsFailure => !IsOk;
    public virtual string Error { get; } = string.Empty;
    public virtual T? Data { get; } = default;
}

