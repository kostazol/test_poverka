# Поверка расходомеров — WinForms (.NET 9)

Каркас приложения Windows Forms на .NET 9 для последующей реализации проливной поверки.

В проекте подготовлены базовые формы аутентификации и настройки расходомеров.

## Сборка
1. Откройте `PoverkaClient.csproj` в Visual Studio 2022 (17.11+) или Rider.
2. Убедитесь, что установлен пакет **.NET 9 SDK**.
3. Соберите и запустите.

## Структура
```
Client/
  Program.cs
  app.manifest
  PoverkaClient.csproj
  Services/
    TokenService.cs
    UserService.cs
  Forms/
    Common/
      LoginForm.cs
      ChangePasswordForm.cs
    Admin/
      ConfigurationForm.cs
    Verifier/
      MetersSetupForm.cs
```

## Что дальше
- Подключение датчиков/стенда: добавить сервис работы с `SerialPort`/Modbus и считывание импульсов/аналоговых датчиков.
