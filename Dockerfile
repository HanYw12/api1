# Imagen base para .NET Core SDK
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Establecer directorio de trabajo
WORKDIR /app

# Copiar archivos de proyecto y restaurar dependencias
COPY *.csproj ./
RUN dotnet restore

# Copiar todos los archivos y compilar la aplicación
COPY . ./
RUN dotnet publish -c Release -o out

# Crear imagen de producción
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./

# Exponer el puerto 80 (donde se ejecutará la aplicación)
EXPOSE 80
ENTRYPOINT ["dotnet", "api1.dll"]
