namespace AndreyAkaSkif.ServiceResult.AspNetCore;

/// <summary>
/// Обёртка для тела HTTP-ответа с сообщением об ошибке
/// </summary>
public readonly struct ErrorMessage
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="title">Сообщение об ошибке</param>
    public ErrorMessage(string? title)
    {
        Title = title;
    }

    /// <summary>
    /// Сообщение об ошибке
    /// </summary>
    public string? Title { get; }
}
