FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/PhishSetlistMonitor.BackgroundService/PhishSetlistMonitor.BackgroundService.csproj", "PhishSetlistMonitor.BackgroundService/"]
RUN dotnet restore "src/PhishSetlistMonitor.BackgroundService/PhishSetlistMonitor.BackgroundService.csproj"
COPY . .
WORKDIR "/src/PhishSetlistMonitor.BackgroundService"
RUN dotnet build "PhishSetlistMonitor.BackgroundService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PhishSetlistMonitor.BackgroundService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PhishSetlistMonitor.BackgroundService.dll"]
