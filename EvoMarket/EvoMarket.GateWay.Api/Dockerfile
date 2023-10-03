FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 12200

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["EvoMarket.GateWay.Api/EvoMarket.GateWay.Api.csproj", "EvoMarket.GateWay.Api/"]
RUN dotnet restore "EvoMarket.GateWay.Api/EvoMarket.GateWay.Api.csproj"
COPY . .
WORKDIR "/src/EvoMarket.GateWay.Api"
RUN dotnet build "EvoMarket.GateWay.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EvoMarket.GateWay.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EvoMarket.GateWay.Api.dll"]
