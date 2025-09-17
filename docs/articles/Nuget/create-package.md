# Создание Nuget-пакетов

## Проект
Добавить в csproj:
```xml
<PropertyGroup>
	<RepositoryUrl>https://github.com/andrey-aka-skif/[ApplicationName]</RepositoryUrl>
	<GeneratePackageOnBuild>True</GeneratePackageOnBuild>
</PropertyGroup>
```

В строке `<RepositoryUrl>https://github.com/andrey-aka-skif/[ApplicationName]</RepositoryUrl>`:
- `andrey-aka-skif` - имя аккаунта
- `[ApplicationName]` - имя пакета

## CI/CD (Github Actions)
Рекомендумеый способ публикации пакетов - через workflow Github Actions (см. файл [ci-cd.yml](https://github.com/andrey-aka-skif/AndreyAkaSkif.ServiceResult/blob/main/.github/workflows/ci-cd.yml)).
