cd .\ApplicationCollector.WebApi\
docker compose up -d
cd..

dotnet ef migrations add InitialCreate -s ApplicationCollector.WebApi -p ApplicationCollector.Infrastructure.Core

dotnet ef database update -s ApplicationCollector.WebApi -p ApplicationCollector.Infrastructure.Core

http://localhost/browser/

adminpassword

app.db

host - postgres
postgres
postgres
5432
postgres
