﻿namespace AndreyAkaSkif.ServiceResult.Implementations;

/// <summary>
/// Не удалось выполнить
/// </summary>
/// <typeparam name="T">Тип возвращаемого объекта</typeparam>
public sealed class InvalidResult<T> : Result<T>
{
    private const string DEFAULT_ERROR_MESSAGE = "Не удалось выполнить операцию";

    public InvalidResult() { }

    public InvalidResult(string error)
    {
        if (!string.IsNullOrWhiteSpace(error))
            Error = error;
    }

    public override string Error { get; } = DEFAULT_ERROR_MESSAGE;
}
