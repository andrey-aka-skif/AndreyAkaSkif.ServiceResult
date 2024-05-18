namespace Result.Implementations;

public sealed class UpdatedResult<T> : Result<T>
{
    public UpdatedResult(T data)
    {
        Data = data;
    }

    public override bool IsOk => true;

    public override T Data { get; }
}
