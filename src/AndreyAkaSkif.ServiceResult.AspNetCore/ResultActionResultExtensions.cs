using Microsoft.AspNetCore.Mvc;
using AndreyAkaSkif.ServiceResult.Abstractions;
using Crud = AndreyAkaSkif.ServiceResult.CrudResults;

namespace AndreyAkaSkif.ServiceResult.AspNetCore;

/// <summary>
/// Маппинг результата сервиса в <see cref="ActionResult"/> (MVC-контроллеры)
/// </summary>
public static class ResultActionResultExtensions
{
    /// <summary>
    /// Привести типизированный результат <see cref="Result{T}"/> к <see cref="ActionResult"/>.
    /// Created → 201 без Location (см. перегрузку с <see cref="ResourceLocationInfo"/>).
    /// </summary>
    public static ActionResult ToActionResult<T>(this Result<T> result) => result switch
    {
        Crud.ConflictResult<T> => new ConflictObjectResult(new ErrorMessage(result.Error)),
        Crud.CreatedResult<T> => new CreatedAtActionResult(null, null, null, result.Data),
        Crud.NotFoundResult<T> => new NotFoundObjectResult(new ErrorMessage(result.Error)),
        Crud.NoContentResult<T> => new NoContentResult(),
        Crud.UpdatedResult<T> => new OkObjectResult(result.Data),
        InvalidResult<T> => new BadRequestObjectResult(new ErrorMessage(result.Error)),
        _ => new OkObjectResult(result.Data),
    };

    /// <summary>
    /// То же, но для CreatedResult заполняет Location (201 Created).
    /// Для остальных типов Location игнорируется.
    /// </summary>
    public static ActionResult ToActionResult<T>(this Result<T> result, ResourceLocationInfo location) =>
        result is Crud.CreatedResult<T>
            ? new CreatedAtActionResult(location.ActionName, location.ControllerName, location.RouteValues, result.Data)
            : result.ToActionResult();

    /// <summary>
    /// Привести нетипизированный результат <see cref="Result"/> к <see cref="ActionResult"/>.
    /// Created → 201 без Location (см. перегрузку с <see cref="ResourceLocationInfo"/>).
    /// </summary>
    public static ActionResult ToActionResult(this Result result) => result switch
    {
        Crud.ConflictResult => new ConflictObjectResult(new ErrorMessage(result.Error)),
        Crud.CreatedResult => new CreatedAtActionResult(null, null, null, null),
        Crud.NotFoundResult => new NotFoundObjectResult(new ErrorMessage(result.Error)),
        Crud.NoContentResult => new NoContentResult(),
        Crud.UpdatedResult => new OkResult(),
        InvalidResult => new BadRequestObjectResult(new ErrorMessage(result.Error)),
        _ => new OkResult(),
    };

    /// <summary>
    /// То же для нетипизированного результата: для CreatedResult
    /// заполняет Location (201 Created).
    /// </summary>
    public static ActionResult ToActionResult(this Result result, ResourceLocationInfo location) =>
        result is Crud.CreatedResult
            ? new CreatedAtActionResult(location.ActionName, location.ControllerName, location.RouteValues, null)
            : result.ToActionResult();
}
