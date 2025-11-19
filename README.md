# ServiceResult
Пакет реализует концепцию Result-паттерна

Идея функционального подхода при возврате значений как объекта Result взята из статьи Владимира Хорикова [Functional C#: Handling failures, input errors](https://enterprisecraftsmanship.com/posts/functional-c-handling-failures-input-errors/). Идея создать отдельный проект взята из его учебного проекта на [github](https://github.com/vkhorikov/CSharpFunctionalExtensions).

Реализация в в значительной мере основана на статье [Clean Up Your Client to Business Logic Relationship With a Result Pattern (C#)](https://alexdunn.org/2019/02/25/clean-up-your-client-to-business-logic-relationship-with-a-result-pattern-c/)

- [Документация проекта](https://andrey-aka-skif.github.io/AndreyAkaSkif.ServiceResult/)
- [Создание пакетов](docs/articles/Nuget/create-package.md)


## Установка пакета

До начала установки нужно явно указать источник пакетов (github, gitea и т.д). Данный вопрос здесь подробно не рассматривается. См. настройки IDE или конфигурационные файлы `nuget.config`.

```shell
dotnet add package AndreyAkaSkif.ServiceResult
```

## Просмотр документации

Документация проекта создана с помощью инструмента [DocFX](https://github.com/dotnet/docfx). Сгенерированная документация расположена на сервисе [github.io](https://andrey-aka-skif.github.io/AndreyAkaSkif.ServiceResult/).

Для просмотра локальной документации использовать команду:
```shell
docfx docs/docfx.json --serve
```
[![Build, Test and Deploy](https://github.com/andrey-aka-skif/AndreyAkaSkif.ServiceResult/actions/workflows/ci-cd.yml/badge.svg)](https://github.com/andrey-aka-skif/AndreyAkaSkif.ServiceResult/actions/workflows/ci-cd.yml)
