FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine AS base
WORKDIR /app
EXPOSE 2505

FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine AS build
WORKDIR /src
COPY ["EvoMarket.Shop.Api/EvoMarket.Shop.Api.csproj", "EvoMarket.Shop.Api/"]
COPY ["EvoMarket.Shop.Service/EvoMarket.Shop.Service.csproj", "EvoMarket.Shop.Service/"]
COPY ["EvoMarket.Infrastructure/EvoMarket.Infrastructure.csproj", "EvoMarket.Infrastructure/"]
COPY ["EvoMarket.WebCore/EvoMarket.WebCore.csproj", "EvoMarket.WebCore/"]
COPY ["Domain/Domain.csproj", "Domain/"]
RUN dotnet restore "EvoMarket.Shop.Api/EvoMarket.Shop.Api.csproj"
COPY . .
WORKDIR "/src/EvoMarket.Shop.Api"
RUN dotnet build "EvoMarket.Shop.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EvoMarket.Shop.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EvoMarket.Shop.Api.dll"]
