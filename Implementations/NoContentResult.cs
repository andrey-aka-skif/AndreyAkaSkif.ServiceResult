namespace Result.Implementations;

public sealed class NoContentResult<T> : Result<T>
{
    public override bool IsOk => true;
}
