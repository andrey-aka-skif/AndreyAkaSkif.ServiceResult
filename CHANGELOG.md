# Журнал изменений

Формат основан на [Keep a Changelog](https://keepachangelog.com/ru/1.1.0/).
Этот проект придерживается [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [3.0.2] - 2026-07-31

### Изменено

- бейдж сборки в README заменён на три бейджа актуальных workflow: CI (`ci.yml`), Docs (`docs.yml`), Release (`release.yml`) — вместо ссылки на удалённый `ci-cd.yml`

## [3.0.1] - 2026-07-31

### Исправлено

- CI/CD: некорректный триггер `create: tags` (событие `create` не поддерживает фильтр по тегам и срабатывало на создание любой ветки/тега) заменён на публикацию по событию `release: published`
- убраны двойные/шумные прогоны workflow

### Изменено

- единый `ci-cd.yml` разделён на три workflow: `ci.yml` (сборка и тесты на пуш в ветку), `docs.yml` (DocFX → GitHub Pages на пуш в `main`), `release.yml` (публикация пакета в GitHub Packages при создании GitHub Release)
- добавлен ручной перезапуск публикации по тегу через `workflow_dispatch`
- GitHub Actions обновлены до актуальных мажоров на Node 24 (Node 20 объявлен deprecated); добавлен Dependabot для автообновления actions

## [3.0.0] - 2026-07-31

### Изменено

- **BREAKING CHANGE**: namespace `AndreyAkaSkif.ServiceResult.BusinessResults` переименован в `AndreyAkaSkif.ServiceResult.CrudResults`
- **BREAKING CHANGE**: целевой фреймворк поднят до net10.0
- **BREAKING CHANGE**: фабрика результатов сведена в единый необобщённый `ResultFactory` с обобщёнными методами; префикс `Create` убран (например, `ResultFactory<T>.CreateSuccessResult(data)` → `ResultFactory.Success(data)`, `ResultFactory.CreateNotFoundResult()` → `ResultFactory.NotFound()`)
- версия пакета задаётся из релизного тега и больше не хранится в исходнике

### Добавлено

- метаданные NuGet-пакета: описание, теги, лицензия, README (видны в списке пакетов Visual Studio и на nuget.org)
- пакет `AndreyAkaSkif.ServiceResult.AspNetCore`: маппинг результата в HTTP-ответы — `ToActionResult()` (MVC) и `ToIResult()` (minimal API), для типизированных и нетипизированных результатов; `InvalidResult` → 400

## [2.1.4] - 2024-09-17

### Добавлено

- нетипизированные результаты

## [2.1.3] - 2024-09-17

### Добавлено

- версионирование через CI/CD

### Известные проблемы

- версионирование через CI/CD не работает

## [2.1.2] - 2024-09-17

### Изменено

- номер версии проекта

## [2.1.1] - 2024-09-17

### Изменено

- служебная логика CI/CD

## [2.1.0] - 2024-09-17

### Добавлено

- фабрика результатов
- текст MIT лицензии
- CHANGELOG.md
- CI/CD для github workflow

### Изменено

- **BREAKING CHANGE**: конкретные результаты теперь наследуются от `SuccessResult<T>` и `InvalidResult<T>` вместо `Result<T>`

## [2.0.0] - 2024-09-09

### Изменено

- **BREAKING CHANGE**: NET поднят до версии 7.0
- **BREAKING CHANGE**: MIT лицензия

## [1.0.2] - 2024-06-30

### Добавлено

- html документация, сгенерированная на основе DocFX

## [1.0.1] - 2024-05-19

### Добавлено

- DocFX документация

### Изменено

- Namespace классов теперь содержит префикс `AndreyAkaSkif.ServiceResult`

## [1.0.0] - 2024-05-19

### Добавлено

- Базовый абстрактный класс `Result<T>`
- Класс `ConflictResult<T>`, соответствующий результату, при котором произошел конфликт при создании сущности
- Класс `CreatedResult<T>`, соответствующий результату, при котором сущность успешно создана
- Класс `InvalidResult<T>`, соответствующий результату, при котором не удалось выполнить операцию
- Класс `NoContentResult<T>`, соответствующий результату, при котором сущность удалена
- Класс `NotFoundResult<T>`, соответствующий результату, при котором сущность не найдена
- Класс `SuccessResult<T>`, соответствующий результату, при котором операция выполнена успешно
- Класс `UpdatedResult<T>`, соответствующий результату, при котором сущность успешно обновлена
