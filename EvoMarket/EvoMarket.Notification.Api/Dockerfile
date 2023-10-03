FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 5132

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["EvoMarket.Notification.Api/EvoMarket.Notification.Api.csproj", "EvoMarket.Notification.Api/"]
COPY ["EvoMarket.Notification.Services/EvoMarket.Notification.Services.csproj", "EvoMarket.Notification.Services/"]
COPY ["EvoMarket.Infrastructure/EvoMarket.Infrastructure.csproj", "EvoMarket.Infrastructure/"]
COPY ["EvoMarket.WebCore/EvoMarket.WebCore.csproj", "EvoMarket.WebCore/"]
COPY ["Domain/Domain.csproj", "Domain/"]
RUN dotnet restore "EvoMarket.Notification.Api/EvoMarket.Notification.Api.csproj"
COPY . .
WORKDIR "/src/EvoMarket.Notification.Api"
RUN dotnet build "EvoMarket.Notification.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EvoMarket.Notification.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EvoMarket.Notification.Api.dll"]
