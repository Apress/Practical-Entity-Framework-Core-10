# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:10.0-preview AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:10.0-preview AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["InventoryManagerWeb/InventoryManagerWeb.csproj", "InventoryManagerWeb/"]
COPY ["InventoryServiceLayer/EF10_InventoryServiceLayer.csproj", "InventoryServiceLayer/"]
COPY ["EF10_DataLayer/EF10_InventoryDataLayer.csproj", "EF10_DataLayer/"]
COPY ["EF10_InventoryDBLibrary/EF10_InventoryDBLibrary.csproj", "EF10_InventoryDBLibrary/"]
COPY ["EF10_InventoryModels/EF10_InventoryModels.csproj", "EF10_InventoryModels/"]
COPY ["Directory.Build.props", "Directory.Build.props"]

RUN dotnet restore "./InventoryManagerWeb/InventoryManagerWeb.csproj"
COPY . .
WORKDIR "/src/InventoryManagerWeb"
RUN dotnet build "./InventoryManagerWeb.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./InventoryManagerWeb.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InventoryManagerWeb.dll"]