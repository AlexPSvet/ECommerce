# 🛒 E-Commerce - Full Stack Application

A modern E-Commerce application built with .NET 10, Blazor WebAssembly, and SQL Server.

## Architecture

- **Frontend**: Blazor WebAssembly (SPA)
- **Backend**: ASP.NET Core Web API
- **Database**: SQL Server 2022
- **ORM**: Entity Framework Core 10
- **Containerization**: Docker & Docker Compose

## Project Structure

```text
ECommerce/
├── ECommerce.Api/           # ASP.NET Core REST API
│   ├── Controllers/         # API Controllers
│   ├── Data/                # DbContext and configurations
│   └── Dockerfile           # API Docker image
├── ECommerce.Blazor/        # Blazor WASM Frontend
│   ├── Pages/               # Razor Pages
│   ├── Services/            # HTTP Services (ProductService)
│   ├── Dockerfile           # Blazor Docker image
│   └── nginx.conf           # Nginx configuration
├── ECommerce.Core/          # Shared Library
│   ├── DTOs/                # Data Transfer Objects
│   ├── Entities/            # Domain Entities
│   └── Models/              # Models (PagedResult, etc.)
├── docker-compose.yml       # Docker Orchestration (Production)
├── docker-compose.dev.yml   # SQL Server Only (Development)
└── docker-manager.ps1       # Docker Management Script
```

## Quick Start

### Option 1: Docker (Recommended)

**Prerequisites:** Docker Desktop installed

```bash
# Start all services (API + Blazor + SQL Server)
docker-compose up -d

# Wait 30–60 seconds, then access:
# - Application: http://localhost:8080
# - API Swagger: http://localhost:5000
```

### Option 2: Local Development

**Prerequisites:**

- .NET 10 SDK
- Visual Studio 2026 or VS Code

#### 1. Start SQL Server (Docker only)

```bash
docker-compose -f docker-compose.dev.yml up -d
```

#### 2. Run the API

```bash
cd ECommerce.Api
dotnet run
```

#### 3. Run Blazor

```bash
cd ECommerce.Blazor
dotnet run
```

## Useful Commands

### Docker

```bash
# Start services
docker-compose up -d

# View logs
docker-compose logs -f

# Stop services
docker-compose down

# Rebuild after changes
docker-compose up -d --build
```

### Development

```bash
# Build solution
dotnet build

# Run tests
dotnet test

# EF Core Migrations
dotnet ef migrations add InitialCreate --project ECommerce.Api
dotnet ef database update --project ECommerce.Api
```

## Technologies Used

### Backend

- .NET 10
- ASP.NET Core Web API
- Entity Framework Core 10
- SQL Server 2022
- Swagger/OpenAPI

### Frontend

- Blazor WebAssembly
- Bootstrap 5
- C# 14

### DevOps

- Docker
- Docker Compose
- Nginx (for serving Blazor WebAssembly in production)

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch:

   ```bash
   git checkout -b feature/AmazingFeature
   ```

3. Commit your changes:

   ```bash
   git commit -m "Add some AmazingFeature"
   ```

4. Push to your branch:

   ```bash
   git push origin feature/AmazingFeature
   ```

5. Open a Pull Request

## License

This project is licensed under the MIT License. See the `LICENSE` file for details.