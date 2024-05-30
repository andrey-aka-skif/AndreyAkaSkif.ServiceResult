# Создание Nuget-пакетов

## Проект
### Файл проекта
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

### NuGet.Config
Создать файл `NuGet.Config` в корне проекта:

```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
	<packageSources>
		<clear />
		<add key="github" value="https://nuget.pkg.github.com/andrey-aka-skif/index.json" />
	</packageSources>
	<packageSourceCredentials>
		<github>
			<add key="Username" value="andrey-aka-skif" />
			<add key="ClearTextPassword" value="%github_access_token%" />
		</github>
	</packageSourceCredentials>
</configuration>
```

Здесь:
- `andrey-aka-skif` - имя аккаунта
- `%github_access_token%` - персональный токен GitHub, который взят из переменной окружения `%github_access_token%`. Указанную переменную нужно добавить к переменным окружения.
