FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/ResponseCompression.NoCompression.API/ResponseCompression.NoCompression.API.csproj", "src/ResponseCompression.NoCompression.API/"]
COPY ["src/ResponseCompression.ApplicationService/ResponseCompression.ApplicationService.csproj", "src/ResponseCompression.ApplicationService/"]
COPY ["src/ResponseCompression.Domain/ResponseCompression.Domain.csproj", "src/ResponseCompression.Domain/"]
RUN dotnet restore "./src/ResponseCompression.NoCompression.API/ResponseCompression.NoCompression.API.csproj"
COPY . .
WORKDIR "/src/src/ResponseCompression.NoCompression.API"
RUN dotnet build "./ResponseCompression.NoCompression.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ResponseCompression.NoCompression.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ResponseCompression.NoCompression.API.dll"]