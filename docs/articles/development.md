# Разработка

## Общие настройки решения

Общие для всех проектов настройки вынесены в корневые файлы решения, чтобы не
дублировать их в каждом `.csproj`:

- **`Directory.Build.props`** — `TargetFramework` (net10.0), `Nullable`,
  `ImplicitUsings`, `LangVersion`, а также .NET-анализаторы
  (`EnableNETAnalyzers`, `AnalysisLevel=latest-recommended`).
- **`Directory.Packages.props`** — централизованное управление версиями пакетов
  (Central Package Management): версии `PackageReference` задаются здесь.

## Метаданные пакета

В `.csproj` проекта-пакета задаются метаданные (видны в списке пакетов Visual Studio
и на странице пакета):

```xml
<PropertyGroup>
	<RepositoryUrl>https://github.com/andrey-aka-skif/AndreyAkaSkif.ServiceResult</RepositoryUrl>
	<RepositoryType>git</RepositoryType>
	<GeneratePackageOnBuild>True</GeneratePackageOnBuild>
</PropertyGroup>

<PropertyGroup>
	<Authors>andrey-aka-skif</Authors>
	<Title>...</Title>
	<Description>...</Description>
	<PackageTags>result;result-pattern;dotnet;csharp</PackageTags>
	<PackageLicenseExpression>MIT</PackageLicenseExpression>
	<PackageProjectUrl>https://andrey-aka-skif.github.io/AndreyAkaSkif.ServiceResult/</PackageProjectUrl>
	<PackageReadmeFile>README.md</PackageReadmeFile>
</PropertyGroup>

<ItemGroup>
	<None Include="..\..\README.md" Pack="true" PackagePath="\" />
</ItemGroup>
```

`PackageReadmeFile` требует, чтобы README был упакован (`None Include ... Pack="true"`).

## Версия пакета

Версия **не хранится** в исходнике (в `.csproj` нет `<Version>`). Она задаётся из
тега релиза `v*.*.*` в CI при упаковке: `dotnet pack -p:Version=<версия>`.

## CI/CD (GitHub Actions)

Логика разделена на три workflow:

- **[ci.yml](https://github.com/andrey-aka-skif/AndreyAkaSkif.ServiceResult/blob/main/.github/workflows/ci.yml)** —
  сборка и тесты на пуш в любую ветку (валидация). Статус виден в PR.
- **[docs.yml](https://github.com/andrey-aka-skif/AndreyAkaSkif.ServiceResult/blob/main/.github/workflows/docs.yml)** —
  сборка DocFX и деплой на GitHub Pages на пуш в `main` (и по ручному запуску).
- **[release.yml](https://github.com/andrey-aka-skif/AndreyAkaSkif.ServiceResult/blob/main/.github/workflows/release.yml)** —
  публикация пакетов в GitHub Packages.

### Как выпустить релиз

1. Влить изменения в `main` (обновив `CHANGELOG.md`).
2. Создать **GitHub Release** с тегом `vX.Y.Z` (через UI или `gh release create vX.Y.Z`).
   Событие `release: published` запускает `release.yml`, который собирает и публикует
   пакеты с версией из тега.

Голый `git push` тега публикацию **не** запускает — это осознанно (релиз оформляется
как GitHub Release с release notes). Для повторной публикации по существующему тегу
есть ручной запуск `release.yml` через `workflow_dispatch` (вход `tag`).

## Документация (DocFX)

DocFX подключён как локальный инструмент (`.config/dotnet-tools.json`). Сборка и
локальный просмотр документации:

```shell
dotnet tool restore
dotnet docfx docs/docfx.json --serve
```
