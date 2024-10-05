FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/ResponseCompression.API/ResponseCompression.API.csproj", "src/ResponseCompression.API/"]
COPY ["src/ResponseCompression.ApplicationService/ResponseCompression.ApplicationService.csproj", "src/ResponseCompression.ApplicationService/"]
COPY ["src/ResponseCompression.Domain/ResponseCompression.Domain.csproj", "src/ResponseCompression.Domain/"]
RUN dotnet restore "./src/ResponseCompression.API/ResponseCompression.API.csproj"
COPY . .
WORKDIR "/src/src/ResponseCompression.API"
RUN dotnet build "./ResponseCompression.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ResponseCompression.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ResponseCompression.API.dll"]