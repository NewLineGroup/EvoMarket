FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 1211

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["EvoMarket.Payment.Api/EvoMarket.Payment.Api.csproj", "EvoMarket.Payment.Api/"]
COPY ["EvoMarket.Payment.Service/EvoMarket.Payment.Service.csproj", "EvoMarket.Payment.Service/"]
COPY ["EvoMarket.Infrastructure/EvoMarket.Infrastructure.csproj", "EvoMarket.Infrastructure/"]
COPY ["EvoMarket.WebCore/EvoMarket.WebCore.csproj", "EvoMarket.WebCore/"]
COPY ["Domain/Domain.csproj", "Domain/"]
RUN dotnet restore "EvoMarket.Payment.Api/EvoMarket.Payment.Api.csproj"
COPY . .
WORKDIR "/src/EvoMarket.Payment.Api"
RUN dotnet build "EvoMarket.Payment.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EvoMarket.Payment.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EvoMarket.Payment.Api.dll"]
