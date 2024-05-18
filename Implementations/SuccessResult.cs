namespace AndreyAkaSkif.ServiceResult.Implementations;

public sealed class SuccessResult<T> : Result<T>
{
    public SuccessResult(T data)
    {
        Data = data;
    }

    public override bool IsOk => true;

    public override T Data { get; }
}
