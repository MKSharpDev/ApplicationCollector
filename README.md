Выбраем директорию в которой нахождится docker compose:
cd .\ApplicationCollector.WebApi

Запусакаем докер:
docker compose up -d
выходим в копрень проекта: cd..

Запусакаем обновление БД:
dotnet ef database update -s ApplicationCollector.WebApi -p ApplicationCollector.Infrastructure.Core

Если необходим pgAdmin:

Заходим http://localhost/browser/
Пароль pgAdmin adminpassword

Регистрируем сервер
app.db

В connection указываем
host - postgres  /
maintenance database  - postgres  /
user - postgres  /
port - 5432  /
password - postgres

При необходимости миграции:
dotnet ef migrations add InitialCreate -s ApplicationCollector.WebApi -p ApplicationCollector.Infrastructure.Core

