# Введение

Реализация Result-паттерна

Идея функционального подхода при возврате значений как объекта Result взята из статьи Владимира Хорикова [Functional C#: Handling failures, input errors](https://enterprisecraftsmanship.com/posts/functional-c-handling-failures-input-errors/). Идея создать отдельный проект взята из его учебного проекта на [github](https://github.com/vkhorikov/CSharpFunctionalExtensions).

Реализация Result в основном основана на статье [Clean Up Your Client to Business Logic Relationship With a Result Pattern (C#)](https://alexdunn.org/2019/02/25/clean-up-your-client-to-business-logic-relationship-with-a-result-pattern-c/)

## Пример

```
// BlocksService.cs

public async Task<Result<Block>> GetByIdAsync(int id)
{
    var stationResult = await _stationService.GetDefaultAsync();
    if (stationResult.IsFailure)
        return new BadRequestResult<Block>(STATION_NOT_FOUND_MESSAGE);

    var block = await _context.Blocks.Where(s => !s.IsDeleted)
                                        .Where(s => s.Id == id)
                                        .Where(s => s.Station.Equals(stationResult.Data))
                                        .FirstOrDefaultAsync();

    if (block is null)
        return new NotFoundResult<Block>($"Не найден Блок (id = {id})");

    return new SuccessResult<Block>(block);
}

// BlocksController.cs

public async Task<ActionResult<Block>> GetByIdAsync(int id)
{
    var result = await _service.GetByIdAsync(id);

    if (result.IsOk)
        return Ok(result.Data);

    return NoFound();
}
```
