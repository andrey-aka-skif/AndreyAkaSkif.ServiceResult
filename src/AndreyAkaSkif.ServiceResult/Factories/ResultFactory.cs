namespace AndreyAkaSkif.ServiceResult.Factories;

/// <summary>
/// Фабрика результатов
/// </summary>
/// <typeparam name="T">Тип возвращаемого ресурса</typeparam>
public static class ResultFactory<T>
{
    /// <summary>
    /// Создать результат "выполнено"
    /// </summary>
    /// <param name="data">Тип возвращаемого ресурса</param>
    /// <returns>Результат "выполнено"</returns>
    public static SuccessResult<T> CreateSuccessResult(T data)
    {
        return new SuccessResult<T>(data);
    }

    /// <summary>
    /// Создать результат "не удалось выполнить"
    /// </summary>
    /// <param name="error"></param>
    /// <returns>Результат "не удалось выполнить"</returns>
    public static InvalidResult<T> CreateInvalidResult(string? error = null)
    {
        if (error is null)
            return new InvalidResult<T>();
        return new InvalidResult<T>(error);
    }

    /// <summary>
    /// Создать результат "конфликт при создании ресурса"
    /// </summary>
    /// <param name="error">Ошибка</param>
    /// <returns>Результат "конфликт при создании ресурса"</returns>
    public static ConflictResult<T> CreateConflictResult(string? error = null)
    {
        if (error is null)
            return new ConflictResult<T>();
        return new ConflictResult<T>(error);
    }

    /// <summary>
    /// Создать результат "ресурс создан"
    /// </summary>
    /// <param name="data">Тип возвращаемого ресурса</param>
    /// <returns>Результат "ресурс создан"</returns>
    public static CreatedResult<T> CreateCreatedResult(T data)
    {
        return new CreatedResult<T>(data);
    }

    /// <summary>
    /// Создать результат "ресурс удален"
    /// </summary>
    /// <returns>Результат "ресурс удален"</returns>
    public static NoContentResult<T> CreateNoContentResult()
    {
        return new NoContentResult<T>();
    }

    /// <summary>
    /// Создать результат "ресурс не найден"
    /// </summary>
    /// <param name="error">Ошибка</param>
    /// <returns>Результат "ресурс не найден"</returns>
    public static NotFoundResult<T> CreateNotFoundResult(string? error = null)
    {
        if (error is null)
            return new NotFoundResult<T>();
        return new NotFoundResult<T>(error);
    }

    /// <summary>
    /// Создать результат "ресурс обновлен"
    /// </summary>
    /// <param name="data">Тип возвращаемого ресурса</param>
    /// <returns>Результат "ресурс обновлен"</returns>
    public static UpdatedResult<T> CreateUpdatedResult(T data)
    {
        return new UpdatedResult<T>(data);
    }
}
