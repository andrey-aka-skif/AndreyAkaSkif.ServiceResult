using Microsoft.AspNetCore.Http;
using AndreyAkaSkif.ServiceResult.Abstractions;
using AndreyAkaSkif.ServiceResult.CrudResults;

namespace AndreyAkaSkif.ServiceResult.AspNetCore;

/// <summary>
/// Маппинг результата сервиса в <see cref="IResult"/> (minimal API)
/// </summary>
public static class ResultHttpResultExtensions
{
    /// <summary>
    /// Привести типизированный результат <see cref="Result{T}"/> к <see cref="IResult"/>.
    /// Created → 201 без Location (см. перегрузку с URI).
    /// </summary>
    public static IResult ToIResult<T>(this Result<T> result) => result switch
    {
        ConflictResult<T> => TypedResults.Conflict(new ErrorMessage(result.Error)),
        CreatedResult<T> => TypedResults.Created((string?)null, result.Data),
        NotFoundResult<T> => TypedResults.NotFound(new ErrorMessage(result.Error)),
        NoContentResult<T> => TypedResults.NoContent(),
        UpdatedResult<T> => TypedResults.Ok(result.Data),
        InvalidResult<T> => TypedResults.BadRequest(new ErrorMessage(result.Error)),
        _ => TypedResults.Ok(result.Data),
    };

    /// <summary>
    /// То же, но для CreatedResult заполняет Location из <paramref name="locationUri"/>.
    /// Для остальных типов URI игнорируется.
    /// </summary>
    public static IResult ToIResult<T>(this Result<T> result, string? locationUri) =>
        result is CreatedResult<T>
            ? TypedResults.Created(locationUri, result.Data)
            : result.ToIResult();

    /// <summary>
    /// Привести нетипизированный результат <see cref="Result"/> к <see cref="IResult"/>.
    /// Created → 201 без Location (см. перегрузку с URI).
    /// </summary>
    public static IResult ToIResult(this Result result) => result switch
    {
        ConflictResult => TypedResults.Conflict(new ErrorMessage(result.Error)),
        CreatedResult => TypedResults.Created((string?)null),
        NotFoundResult => TypedResults.NotFound(new ErrorMessage(result.Error)),
        NoContentResult => TypedResults.NoContent(),
        UpdatedResult => TypedResults.Ok(),
        InvalidResult => TypedResults.BadRequest(new ErrorMessage(result.Error)),
        _ => TypedResults.Ok(),
    };

    /// <summary>
    /// То же для нетипизированного результата: для CreatedResult заполняет Location
    /// из <paramref name="locationUri"/>.
    /// </summary>
    public static IResult ToIResult(this Result result, string? locationUri) =>
        result is CreatedResult
            ? TypedResults.Created(locationUri)
            : result.ToIResult();
}
