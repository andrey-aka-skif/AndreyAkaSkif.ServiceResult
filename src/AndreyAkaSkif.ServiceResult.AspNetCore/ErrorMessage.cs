namespace AndreyAkaSkif.ServiceResult.AspNetCore;

/// <summary>
/// Обёртка для тела HTTP-ответа с сообщением об ошибке
/// </summary>
/// <param name="title">Сообщение об ошибке</param>
public readonly struct ErrorMessage(string? title)
{

    /// <summary>
    /// Сообщение об ошибке
    /// </summary>
    public string? Title { get; } = title;
}
