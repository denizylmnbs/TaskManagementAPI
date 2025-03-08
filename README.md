# TaskManagementAPI
ASP.NET Core ile SQL Server destekli bir Task Management API'si. CRUD işlemleri, DTO ve JWT ile güvenlik içerir.

## Özellikler
- GET /api/tasks: Tüm görevleri listeler (JWT ile korunmalı)
- POST /api/tasks: Yeni görev ekler
- POST /register: Kullanıcı kaydı
- POST /login: JWT token ile giriş
- Geçersiz ID için 404 hatası

## Kurulum
1. `dotnet restore`
2. appsettings.json'a SQL Server connection string ekle
3. `dotnet ef database update`
4. `dotnet run`, Swagger ile test et: `https://localhost:5001/swagger`

## Teknolojiler
- ASP.NET Core 9.0
- Entity Framework Core
- SQL Server
- JWT Authentication
