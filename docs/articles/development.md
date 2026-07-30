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
релизного тега `v*.*.*` в CI при упаковке: `dotnet pack -p:Version=<версия>`.

## CI/CD (GitHub Actions)

Рекомендуемый способ публикации — через workflow GitHub Actions (см. файл
[ci-cd.yml](https://github.com/andrey-aka-skif/AndreyAkaSkif.ServiceResult/blob/main/.github/workflows/ci-cd.yml)).

## Документация (DocFX)

DocFX подключён как локальный инструмент (`.config/dotnet-tools.json`). Сборка и
локальный просмотр документации:

```shell
dotnet tool restore
dotnet docfx docs/docfx.json --serve
```
