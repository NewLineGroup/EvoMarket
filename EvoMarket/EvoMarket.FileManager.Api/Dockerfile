FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 12203

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["EvoMarket.FileManager.Api/EvoMarket.FileManager.Api.csproj", "EvoMarket.FileManager.Api/"]
COPY ["Domain/Domain.csproj", "Domain/"]
RUN dotnet restore "EvoMarket.FileManager.Api/EvoMarket.FileManager.Api.csproj"
COPY . .
WORKDIR "/src/EvoMarket.FileManager.Api"
RUN dotnet build "EvoMarket.FileManager.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EvoMarket.FileManager.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EvoMarket.FileManager.Api.dll"]
