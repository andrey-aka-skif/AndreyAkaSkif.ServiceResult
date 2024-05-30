# Публикация Nuget-пакетов

Собрать решение и выполнить команду:
```shell
dotnet nuget push "bin/Release/<ApplicationName>.1.0.0.nupkg"  --source "github"
```

Здесь `1.0.0` - версия, указанная в настройках проекта
