# Build stage
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copy project files
COPY ["ECommerce.Blazor/ECommerce.Blazor.csproj", "ECommerce.Blazor/"]
COPY ["ECommerce.Core/ECommerce.Core.csproj", "ECommerce.Core/"]

# Restore dependencies
RUN dotnet restore "ECommerce.Blazor/ECommerce.Blazor.csproj"

# Copy all source files
COPY . .

# Build and publish the Blazor WASM project
WORKDIR "/src/ECommerce.Blazor"
RUN dotnet publish "ECommerce.Blazor.csproj" -c Release -o /app/publish

# Runtime stage - use nginx to serve static files
FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html

# Copy published Blazor WASM files
COPY --from=build /app/publish/wwwroot .

# Copy custom nginx configuration
COPY ECommerce.Blazor/nginx.conf /etc/nginx/nginx.conf

EXPOSE 80
