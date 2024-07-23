#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["BloggingPlatform.API/BloggingPlatform.API.csproj", "BloggingPlatform.API/"]
COPY ["BloggingPlatform.Application/BloggingPlatform.Application.csproj", "BloggingPlatform.Application/"]
COPY ["BloggingPlatform.Domain/BloggingPlatform.Domain.csproj", "BloggingPlatform.Domain/"]
COPY ["BloggingPlatform.Infrastructure/BloggingPlatform.Infrastructure.csproj", "BloggingPlatform.Infrastructure/"]
RUN dotnet restore "./BloggingPlatform.API/BloggingPlatform.API.csproj"
COPY . .
WORKDIR "/src/BloggingPlatform.API"
RUN dotnet build "./BloggingPlatform.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./BloggingPlatform.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

EXPOSE 8080

ENTRYPOINT ["dotnet", "BloggingPlatform.API.dll"]