# Usa la imagen base de .NET 7.0 SDK para compilar la aplicación
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:5075
ENV ASPNETCORE_ENVIRONMENT=Development
EXPOSE 5075
 
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Copia los archivos de la solución y restaura las dependencias

COPY ["NutritionalKitchen.sln", "."]
COPY ["NutritionalKitchen.Domain/NutritionalKitchen.Domain.csproj", "NutritionalKitchen.Domain/"]
COPY ["NutritionalKitchen.Application/NutritionalKitchen.Application.csproj", "NutritionalKitchen.Application/"]
COPY ["NutritionalKitchen.Infraestructura/NutritionalKitchen.Infraestructura.csproj", "NutritionalKitchen.Infraestructura/"]
COPY ["NutritionalKitchen.WebApi/NutritionalKitchen.WebApi.csproj", "NutritionalKitchen.WebApi/"]

# Restaura los paquetes NuGet
RUN dotnet restore "./NutritionalKitchen.WebApi/NutritionalKitchen.WebApi.csproj"

# Copia todo el código fuente
COPY . .
  
WORKDIR "/src/NutritionalKitchen.WebApi"
RUN dotnet build "NutritionalKitchen.WebApi.csproj" -c Release -o /app/build
 
FROM build AS publish
RUN dotnet publish "./NutritionalKitchen.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false
 
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NutritionalKitchen.WebApi.dll"]