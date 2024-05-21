[Back to Readme](../README.md)

# Проект
## Файл проекта
Добавить в csproj:
```csproj
<PropertyGroup>
	<RepositoryUrl>https://github.com/andrey-aka-skif/AndreyAkaSkif.ServiceResult</RepositoryUrl>
	<GeneratePackageOnBuild>True</GeneratePackageOnBuild>
</PropertyGroup>
```

В строке `<RepositoryUrl>https://github.com/andrey-aka-skif/AndreyAkaSkif.ServiceResult</RepositoryUrl>`:
- `andrey-aka-skif` - имя аккаунта
- `AndreyAkaSkif.ServiceResult` - имя пакета

## NuGet.Config
Создать файл `NuGet.Config`:

```Config
<?xml version="1.0" encoding="utf-8"?>
<configuration>
	<packageSources>
		<clear />
		<add key="github" value="https://nuget.pkg.github.com/andrey-aka-skif/index.json" />
	</packageSources>
	<packageSourceCredentials>
		<github>
			<add key="Username" value="andrey-aka-skif" />
			<add key="ClearTextPassword" value="ghp_apiKey" />
		</github>
	</packageSourceCredentials>
</configuration>
```

Здесь:
- `andrey-aka-skif` - имя аккаунта
- `ghp_apiKey` - персональный токен GitHub

## Отправка в репозиторий
Собрать решение и выполнить команду:
```shell
dotnet nuget push "bin/Release/<ApplicationName>.1.0.0.nupkg"  --source "github"
```

Здесь `1.0.0` - версия, указанная в настройках проекта

См. также:
- Инструкция по созданию NuGet пакета взята из статьи [Using Github as Private Nuget Package Server and Share Your Packages](https://www.codeproject.com/Tips/5292364/Using-Github-as-Private-Nuget-Package-Server-and-S)
- Исправление некоторых проблем с авторизацией при загрузке  пакетов [Private nuget source github returns 401 with correct credentials](https://stackoverflow.com/questions/67793959/private-nuget-source-github-returns-401-with-correct-credentials)

