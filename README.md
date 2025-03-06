# TaskManagementAPI
ASP.NET Core ile SQL Server destekli bir Task Management API'si. CRUD işlemleri ve DTO kullanımı içerir.

## Özellikler
- GET /api/tasks: Tüm görevleri listeler
- POST /api/tasks: Yeni görev ekler
- PUT /api/tasks/{id}: Görevi günceller
- DELETE /api/tasks/{id}: Görevi siler
- Geçersiz ID için 404 hatası

## Kurulum
1. `dotnet restore`
2. appsettings.json'a SQL Server connection string ekle
3. `dotnet ef database update`
4. `dotnet run` ile başlat, Swagger ile test et: `https://localhost:5001/swagger`

## Teknolojiler
- ASP.NET Core 9.0
- Entity Framework Core
- SQL Server
