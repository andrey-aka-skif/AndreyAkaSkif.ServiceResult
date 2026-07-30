namespace AndreyAkaSkif.ServiceResult.AspNetCore;

/// <summary>
/// Информация о расположении созданного ресурса (для 201 Created)
/// </summary>
public readonly struct ResourceLocationInfo
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="actionName">Имя экшена</param>
    /// <param name="controllerName">Имя контроллера</param>
    /// <param name="routeValues">Объект с параметрами маршрута</param>
    /// <exception cref="ArgumentException">Если имя экшена или контроллера пусто</exception>
    /// <exception cref="ArgumentNullException">Если параметры маршрута не заданы</exception>
    public ResourceLocationInfo(string actionName, string controllerName, object routeValues)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(actionName);
        ArgumentException.ThrowIfNullOrWhiteSpace(controllerName);
        ArgumentNullException.ThrowIfNull(routeValues);

        ActionName = actionName;
        ControllerName = controllerName;
        RouteValues = routeValues;
    }

    /// <summary>
    /// Имя экшена
    /// </summary>
    public string ActionName { get; }

    /// <summary>
    /// Имя контроллера
    /// </summary>
    public string ControllerName { get; }

    /// <summary>
    /// Объект с параметрами маршрута
    /// </summary>
    /// <remarks>
    /// Пример: <c>new { id = 42 }</c>. Параметр (например, id) должен существовать
    /// у целевой конечной точки.
    /// </remarks>
    public object RouteValues { get; }
}
