# Data_service
1. Цели задачи:
    • Создать API, который будет принимать неструктурированные адреса.
    • Использовать сторонний сервис Dadata для стандартизации этих адресов.
    • Реализовать качественную архитектуру с применением паттернов DI (Dependency Injection) и AutoMapper.
    
2. Для работы с HttpClient и AutoMapper были установлены соответствующие NuGet-пакеты:
dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection
dotnet add package Newtonsoft.Json
dotnet add package Microsoft.Extensions.Http

3. Определение моделей данных
Созданные модели AddressRequest и AddressResponse представляют собой объекты, с которыми работает API:
    • AddressRequest содержит поле для входного адреса.
    • AddressResponse содержит поле для стандартизованного адреса.

4. Настройка AutoMapper
Создан класс MappingProfile, который помогает преобразовывать объекты запроса и ответа.

6. Создание контроллера
Контроллер AddressController обрабатывает HTTP-запросы, используя сервис Dadata для стандартизации входящего адреса.

7. Настройка DI в Startup.cs
В классе Startup были добавлены все службы, включая AutoMapper, HttpClient, и сервис DadataService.

8. Логирование с использованием NLog:
Настроено логирование для обработки возможных ошибок и отслеживания работы приложения.

9. Конфигурация проекта:
Добавлены настройки в appsettings.json, включая ключи для Dadata API для доступа к стандартам по адресам.

