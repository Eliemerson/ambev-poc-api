FROM mcr.microsoft.com/dotnet/sdk:6.0 AS base
WORKDIR /app
EXPOSE 80

ENV ASPNETCORE_URLS=http://+:8000;http://+:80;
ENV ASPNETCORE_ENVIRONMENT=Development

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY AmBev.Poc.Dev.API/*.csproj AmBev.Poc.Dev.API/
RUN dotnet restore
COPY . .

WORKDIR /src/AmBev.Poc.Dev.API
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .

ENTRYPOINT ["dotnet", "AmBev.Poc.Dev.API.dll"]