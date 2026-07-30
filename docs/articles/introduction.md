# Обзор

Реализация Result-паттерна

Пакет реализует концепцию Result-паттерна: операция возвращает типизированный объект результата (успех/ошибка) вместо выброса исключений.

Это не функциональная обёртка (нет `Map`/`Bind`), а типизированный контейнер результата в ООП-стиле. Идея возвращать результат объектом `Result` вдохновлена статьёй Владимира Хорикова [Functional C#: Handling failures, input errors](https://enterprisecraftsmanship.com/posts/functional-c-handling-failures-input-errors/) и его учебным проектом [CSharpFunctionalExtensions](https://github.com/vkhorikov/CSharpFunctionalExtensions).

Реализация в значительной мере основана на статье [Clean Up Your Client to Business Logic Relationship With a Result Pattern (C#)](https://alexdunn.org/2019/02/25/clean-up-your-client-to-business-logic-relationship-with-a-result-pattern-c/)

## Результаты

Конкретные результаты можно создавать напрямую конструктором либо через фабрику `ResultFactory` (`AndreyAkaSkif.ServiceResult.Factories`). CRUD-результаты (`CreatedResult`, `UpdatedResult`, `NoContentResult`, `NotFoundResult`, `ConflictResult`) находятся в `AndreyAkaSkif.ServiceResult.CrudResults`.

```csharp
// напрямую конструктором
return new SuccessResult<Block>(block);
return new NotFoundResult<Block>($"Не найден Блок (id = {id})");

// либо через фабрику (тип выводится из аргумента)
return ResultFactory.Success(block);
return ResultFactory.NotFound<Block>($"Не найден Блок (id = {id})");
```

## Пример

Сервис возвращает `Result<Block>`, а контроллер приводит результат к HTTP-ответу
методом `ToActionResult()` из пакета `AndreyAkaSkif.ServiceResult.AspNetCore`.

```csharp
// BlocksService.cs

public async Task<Result<Block>> GetByIdAsync(int id)
{
    var stationResult = await _stationService.GetDefaultAsync();
    if (stationResult.IsFailure)
        return new InvalidResult<Block>(STATION_NOT_FOUND_MESSAGE);

    var block = await _context.Blocks.Where(s => !s.IsDeleted)
                                        .Where(s => s.Id == id)
                                        .Where(s => s.Station.Equals(stationResult.Data))
                                        .FirstOrDefaultAsync();

    if (block is null)
        return new NotFoundResult<Block>($"Не найден Блок (id = {id})");

    return new SuccessResult<Block>(block);
}

// BlocksController.cs (MVC)

public async Task<ActionResult<Block>> GetByIdAsync(int id)
{
    var result = await _service.GetByIdAsync(id);
    return result.ToActionResult();
}
```

В minimal API тот же результат приводится к `IResult` методом `ToIResult()`:

```csharp
app.MapGet("/blocks/{id:int}", async (int id, BlocksService service) =>
{
    var result = await service.GetByIdAsync(id);
    return result.ToIResult();
});
```

## Создание ресурса (201 Created с Location)

Для `CreatedResult` есть перегрузки, заполняющие заголовок `Location` — ссылку на
созданный ресурс. Сервис возвращает `CreatedResult<Block>` (или `ResultFactory.Created(block)`):

```csharp
// BlocksService.cs

public async Task<Result<Block>> CreateAsync(BlockDto dto)
{
    // ... проверки, при конфликте: return new ConflictResult<Block>();
    var block = await _repository.AddAsync(dto);
    return new CreatedResult<Block>(block);
}
```

В MVC `Location` собирается по экшену чтения через `ResourceLocationInfo`
(имя экшена, имя контроллера, значения маршрута):

```csharp
// BlocksController.cs (MVC)

public async Task<ActionResult<Block>> CreateAsync(BlockDto dto)
{
    var result = await _service.CreateAsync(dto);
    return result.ToActionResult(
        new ResourceLocationInfo(nameof(GetByIdAsync), "Blocks", new { id = result.Data?.Id }));
}
```

В minimal API `Location` задаётся URI:

```csharp
app.MapPost("/blocks", async (BlockDto dto, BlocksService service) =>
{
    var result = await service.CreateAsync(dto);
    return result.ToIResult($"/blocks/{result.Data?.Id}");
});
```

Перегрузки с Location безопасны для любого результата: если результат — не `CreatedResult`,
заданный `Location`/URI игнорируется, и маппинг идёт как в обычной перегрузке.

## Маппинг статусов

`SuccessResult`/`UpdatedResult` → 200, `CreatedResult` → 201, `NoContentResult` → 204,
`InvalidResult` → 400, `NotFoundResult` → 404, `ConflictResult` → 409.
