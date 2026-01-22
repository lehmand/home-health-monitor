FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /app

COPY ["src/Services/Sensor/Sensor.API/Sensor.API.csproj", "src/Services/Sensor/Sensor.API/"]
COPY ["src/Services/Sensor/Sensor.Application/Sensor.Application.csproj", "src/Services/Sensor/Sensor.Application/"]
COPY ["src/Services/Sensor/Sensor.Domain/Sensor.Domain.csproj", "src/Services/Sensor/Sensor.Domain/"]
COPY ["src/Services/Sensor/Sensor.Infrastructure/Sensor.Infrastructure.csproj", "src/Services/Sensor/Sensor.Infrastructure/"]

RUN dotnet restore "src/Services/Sensor/Sensor.API/Sensor.API.csproj"

COPY . .

WORKDIR /app/src/Services/Sensor/Sensor.API/
RUN dotnet publish "Sensor.API.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Sensor.API.dll"]