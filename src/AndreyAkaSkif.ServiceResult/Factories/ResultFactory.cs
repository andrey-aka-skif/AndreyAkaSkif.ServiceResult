namespace AndreyAkaSkif.ServiceResult.Factories;

/// <summary>
/// Фабрика результатов
/// </summary>
public static class ResultFactory
{
    /// <summary>Результат "выполнено"</summary>
    public static SuccessResult Success() => new();

    /// <summary>Результат "выполнено" с ресурсом</summary>
    /// <typeparam name="T">Тип возвращаемого ресурса</typeparam>
    /// <param name="data">Возвращаемый ресурс</param>
    public static SuccessResult<T> Success<T>(T data) => new(data);

    /// <summary>Результат "не удалось выполнить"</summary>
    /// <param name="error">Сообщение об ошибке; при <see langword="null"/> — по умолчанию</param>
    public static InvalidResult Invalid(string? error = null)
        => error is null ? new() : new(error);

    /// <summary>Результат "не удалось выполнить"</summary>
    /// <typeparam name="T">Тип возвращаемого ресурса</typeparam>
    /// <param name="error">Сообщение об ошибке; при <see langword="null"/> — по умолчанию</param>
    public static InvalidResult<T> Invalid<T>(string? error = null)
        => error is null ? new() : new(error);

    /// <summary>Результат "конфликт при создании ресурса"</summary>
    /// <param name="error">Сообщение об ошибке; при <see langword="null"/> — по умолчанию</param>
    public static ConflictResult Conflict(string? error = null)
        => error is null ? new() : new(error);

    /// <summary>Результат "конфликт при создании ресурса"</summary>
    /// <typeparam name="T">Тип возвращаемого ресурса</typeparam>
    /// <param name="error">Сообщение об ошибке; при <see langword="null"/> — по умолчанию</param>
    public static ConflictResult<T> Conflict<T>(string? error = null)
        => error is null ? new() : new(error);

    /// <summary>Результат "ресурс создан"</summary>
    public static CreatedResult Created() => new();

    /// <summary>Результат "ресурс создан"</summary>
    /// <typeparam name="T">Тип возвращаемого ресурса</typeparam>
    /// <param name="data">Созданный ресурс</param>
    public static CreatedResult<T> Created<T>(T data) => new(data);

    /// <summary>Результат "ресурс удалён"</summary>
    public static NoContentResult NoContent() => new();

    /// <summary>Результат "ресурс удалён"</summary>
    /// <typeparam name="T">Тип возвращаемого ресурса</typeparam>
    public static NoContentResult<T> NoContent<T>() => new();

    /// <summary>Результат "ресурс не найден"</summary>
    /// <param name="error">Сообщение об ошибке; при <see langword="null"/> — по умолчанию</param>
    public static NotFoundResult NotFound(string? error = null)
        => error is null ? new() : new(error);

    /// <summary>Результат "ресурс не найден"</summary>
    /// <typeparam name="T">Тип возвращаемого ресурса</typeparam>
    /// <param name="error">Сообщение об ошибке; при <see langword="null"/> — по умолчанию</param>
    public static NotFoundResult<T> NotFound<T>(string? error = null)
        => error is null ? new() : new(error);

    /// <summary>Результат "ресурс обновлён"</summary>
    public static UpdatedResult Updated() => new();

    /// <summary>Результат "ресурс обновлён"</summary>
    /// <typeparam name="T">Тип возвращаемого ресурса</typeparam>
    /// <param name="data">Обновлённый ресурс</param>
    public static UpdatedResult<T> Updated<T>(T data) => new(data);
}
