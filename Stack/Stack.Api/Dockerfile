
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Stack.Api/Stack.Api.csproj", "Stack.Api/"]
COPY ["Stack.Application/Stack.Application.csproj", "Stack.Application/"]
COPY ["Stack.Domain/Stack.Domain.csproj", "Stack.Domain/"]
COPY ["Stack.Infrastructure/Stack.Infrastructure.csproj", "Stack.Infrastructure/"]
RUN dotnet restore "./Stack.Api/./Stack.Api.csproj"
COPY . .
WORKDIR "/src/Stack.Api"
RUN dotnet build "./Stack.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Stack.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

ENV ASPNETCORE_ENVIRONMENT Docker

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Stack.Api.dll"]