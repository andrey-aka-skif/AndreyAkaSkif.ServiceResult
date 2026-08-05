# ServiceResult

[![CI](https://github.com/andrey-aka-skif/AndreyAkaSkif.ServiceResult/actions/workflows/ci.yml/badge.svg)](https://github.com/andrey-aka-skif/AndreyAkaSkif.ServiceResult/actions/workflows/ci.yml)
[![Release](https://github.com/andrey-aka-skif/AndreyAkaSkif.ServiceResult/actions/workflows/release.yml/badge.svg)](https://github.com/andrey-aka-skif/AndreyAkaSkif.ServiceResult/actions/workflows/release.yml)
[![GitHub license](https://img.shields.io/github/license/mashape/apistatus.svg)](https://github.com/andrey-aka-skif/AndreyAkaSkif.ServiceResult/blob/main/LICENSE)
[![Docs](https://github.com/andrey-aka-skif/AndreyAkaSkif.ServiceResult/actions/workflows/docs.yml/badge.svg)](https://github.com/andrey-aka-skif/AndreyAkaSkif.ServiceResult/actions/workflows/docs.yml)

Пакет реализует концепцию Result-паттерна: операция возвращает типизированный объект результата (успех/ошибка) вместо выброса исключений.

Это не функциональная обёртка (нет `Map`/`Bind`), а типизированный контейнер результата в ООП-стиле. Идея возвращать результат объектом `Result` вдохновлена статьёй Владимира Хорикова [Functional C#: Handling failures, input errors](https://enterprisecraftsmanship.com/posts/functional-c-handling-failures-input-errors/) и его учебным проектом [CSharpFunctionalExtensions](https://github.com/vkhorikov/CSharpFunctionalExtensions).

Реализация в значительной мере основана на статье [Clean Up Your Client to Business Logic Relationship With a Result Pattern (C#)](https://alexdunn.org/2019/02/25/clean-up-your-client-to-business-logic-relationship-with-a-result-pattern-c/)

- [Документация проекта](https://andrey-aka-skif.github.io/AndreyAkaSkif.ServiceResult/)
- [Разработка](docs/articles/development.md)


## Установка пакета

До начала установки нужно явно указать источник пакетов (github, gitea и т.д). Данный вопрос здесь подробно не рассматривается. См. настройки IDE или конфигурационные файлы `nuget.config`.

```shell
dotnet add package AndreyAkaSkif.ServiceResult
```

## Просмотр документации

Документация проекта создана с помощью инструмента [DocFX](https://github.com/dotnet/docfx). Сгенерированная документация расположена на сервисе [github.io](https://andrey-aka-skif.github.io/AndreyAkaSkif.ServiceResult/).

Для просмотра локальной документации использовать команды (docfx подключён как локальный инструмент):
```shell
dotnet tool restore
dotnet docfx docs/docfx.json --serve
```
