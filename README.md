# 🛒 ECommerce - Full Stack Application

Application E-Commerce moderne construite avec .NET 10, Blazor WebAssembly et SQL Server.

## Architecture

- **Frontend** : Blazor WebAssembly (SPA)
- **Backend** : ASP.NET Core Web API
- **Database** : SQL Server 2022
- **ORM** : Entity Framework Core 10
- **Containerization** : Docker & Docker Compose

## Structure du projet

```
ECommerce/
├── ECommerce.Api/           # API REST ASP.NET Core
│   ├── Controllers/         # Contrôleurs API
│   ├── Data/               # DbContext et configurations
│   └── Dockerfile          # Image Docker API
├── ECommerce.Blazor/        # Frontend Blazor WASM
│   ├── Pages/              # Pages Razor
│   ├── Services/           # Services HTTP (ProductService)
│   ├── Dockerfile          # Image Docker Blazor
│   └── nginx.conf          # Configuration Nginx
├── ECommerce.Core/          # Librairie partagée
│   ├── DTOs/               # Data Transfer Objects
│   ├── Entities/           # Entités de domaine
│   └── Models/             # Modèles (PagedResult, etc.)
├── docker-compose.yml       # Orchestration Docker (Production)
├── docker-compose.dev.yml   # Docker SQL Server uniquement (Dev)
└── docker-manager.ps1       # Script de gestion Docker
```

## Démarrage rapide

### Option 1 : Docker (Recommandé)

**Prérequis** : Docker Desktop installé

```bash
# Démarrer tous les services (API + Blazor + SQL Server)
docker-compose up -d

# Attendre 30-60 secondes puis accéder à :
# - Application : http://localhost:8080
# - API Swagger : http://localhost:5000
```

**Avec PowerShell :**
```powershell
.\docker-manager.ps1 start
```

### Option 2 : Développement local

**Prérequis** :
- .NET 10 SDK
- Visual Studio 2026 ou VS Code

**1. Démarrer SQL Server (Docker uniquement)**
```bash
docker-compose -f docker-compose.dev.yml up -d
```

**2. Lancer l'API**
```bash
cd ECommerce.Api
dotnet run
```

**3. Lancer Blazor**
```bash
cd ECommerce.Blazor
dotnet run
```

**Guide détaillé**

## URLs d'accès

### Mode Production (Docker complet)
- **Application Blazor** : http://localhost:8080
- **API Documentation** : http://localhost:5000
- **SQL Server** : localhost:1433

### Mode Développement (Local)
- **API** : https://localhost:7128 ou http://localhost:5128
- **Blazor** : https://localhost:7001
- **SQL Server** : localhost:1433

## Commandes utiles

### Docker

```bash
# Démarrer
docker-compose up -d

# Voir les logs
docker-compose logs -f

# Arrêter
docker-compose down

# Rebuild après modifications
docker-compose up -d --build
```

### Développement

```bash
# Build
dotnet build

# Tests
dotnet test

# Migrations EF Core
dotnet ef migrations add InitialCreate --project ECommerce.Api
dotnet ef database update --project ECommerce.Api
```

## Configuration

### Connection String (SQL Server)

**Docker :** Configuré automatiquement dans `docker-compose.yml`

**Local :** Modifier `ECommerce.Api/appsettings.json`
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=ECommerceDb;User Id=sa;Password=YourStrong@Passw0rd;TrustServerCertificate=True;"
  }
}
```

### API Base URL (Blazor)

Modifier `ECommerce.Blazor/wwwroot/appsettings.json`
```json
{
  "ApiBaseUrl": "http://localhost:5000/api"
}
```

## Technologies utilisées

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
- Nginx (pour servir Blazor WASM en prod)

## Services créés

### ProductService (Blazor)
Interface permettant de consommer l'API produits :

```csharp
// Injection dans un composant Razor
@inject IProductService ProductService

@code {
    protected override async Task OnInitializedAsync()
    {
        var products = await ProductService.GetProductsAsync(page: 1, pageSize: 10);
    }
}
```

## 🤝 Contribution

1. Fork le projet
2. Créer une branche feature (`git checkout -b feature/AmazingFeature`)
3. Commit les changements (`git commit -m 'Add some AmazingFeature'`)
4. Push vers la branche (`git push origin feature/AmazingFeature`)
5. Ouvrir une Pull Request