FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["EvoMarket.Notification.Api/EvoMarket.Notification.Api.csproj", "EvoMarket.Notification.Api/"]
RUN dotnet restore "EvoMarket.Notification.Api/EvoMarket.Notification.Api.csproj"
COPY . .
WORKDIR "/src/EvoMarket.Notification.Api"
RUN dotnet build "EvoMarket.Notification.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EvoMarket.Notification.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EvoMarket.Notification.Api.dll"]
