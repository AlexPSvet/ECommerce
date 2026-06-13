# Build stage
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copy project files
COPY ["ECommerce.Api/ECommerce.Api.csproj", "ECommerce.Api/"]
COPY ["ECommerce.Core/ECommerce.Core.csproj", "ECommerce.Core/"]

# Restore dependencies
RUN dotnet restore "ECommerce.Api/ECommerce.Api.csproj"

# Copy all source files
COPY . .

# Build the project
WORKDIR "/src/ECommerce.Api"
RUN dotnet build "ECommerce.Api.csproj" -c Release -o /app/build

# Publish stage
FROM build AS publish
RUN dotnet publish "ECommerce.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ECommerce.Api.dll"]
