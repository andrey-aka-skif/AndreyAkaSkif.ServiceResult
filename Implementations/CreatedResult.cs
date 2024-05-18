namespace Result.Implementations;

public sealed class CreatedResult<T> : Result<T>
{
    public CreatedResult(T data)
    {
        Data = data;
    }

    public override bool IsOk => true;

    public override T Data { get; }
}
