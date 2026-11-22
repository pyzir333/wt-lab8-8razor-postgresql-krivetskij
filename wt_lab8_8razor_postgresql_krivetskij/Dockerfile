
# Этап 1. Сборка приложения
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["wt_lab8_8razor_postgresql_krivetskij/wt_lab8_8razor_postgresql_krivetskij.csproj", "./"]
RUN dotnet restore "wt_lab8_8razor_postgresql_krivetskij.csproj"

COPY wt_lab8_8razor_postgresql_krivetskij/. .
RUN dotnet publish "wt_lab8_8razor_postgresql_krivetskij.csproj" \
    -c Release \
    -o /app/publish \
    /p:UseAppHost=false

# Этап 2. Запуск приложения
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 10000

ENTRYPOINT ["sh", "-c", "dotnet wt_lab8_8razor_postgresql_krivetskij.dll --urls http://0.0.0.0:${PORT:-10000}"]
