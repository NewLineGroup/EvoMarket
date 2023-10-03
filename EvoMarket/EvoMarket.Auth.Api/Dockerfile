FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 1214

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["EvoMarket.Auth.Api/EvoMarket.Auth.Api.csproj", "EvoMarket.Auth.Api/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["EvoMarket.Auth.Service/EvoMarket.Auth.Service.csproj", "EvoMarket.Auth.Service/"]
COPY ["EvoMarket.Infrastructure/EvoMarket.Infrastructure.csproj", "EvoMarket.Infrastructure/"]
COPY ["EvoMarket.WebCore/EvoMarket.WebCore.csproj", "EvoMarket.WebCore/"]
COPY ["EvoMarket.Notification.Services/EvoMarket.Notification.Services.csproj", "EvoMarket.Notification.Services/"]
COPY ["EvoMarket.Shop.Service/EvoMarket.Shop.Service.csproj", "EvoMarket.Shop.Service/"]
RUN dotnet restore "EvoMarket.Auth.Api/EvoMarket.Auth.Api.csproj"
COPY . .
WORKDIR "/src/EvoMarket.Auth.Api"
RUN dotnet build "EvoMarket.Auth.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EvoMarket.Auth.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EvoMarket.Auth.Api.dll"]
