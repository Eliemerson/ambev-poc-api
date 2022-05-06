FROM mcr.microsoft.com/dotnet/sdk:6.0 AS base
WORKDIR /app
EXPOSE 80

ENV ASPNETCORE_URLS=http://+:8000;http://+:80;
ENV ASPNETCORE_ENVIRONMENT=Development

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY AmBev-Poc-DEV.sln ./
COPY Ambev.Poc.Dev.Data/*.csproj ./Ambev.Poc.Dev.Data/
COPY Ambev.Poc.Dev.Domain/*.csproj ./Ambev.Poc.Dev.Domain/
COPY AmBev.Poc.Dev.API/*.csproj ./AmBev.Poc.Dev.API/
COPY Ambev.Poc.Dev.Domain.Test/*.csproj ./Ambev.Poc.Dev.Domain.Test/

RUN dotnet restore
COPY . .
WORKDIR /src/Ambev.Poc.Dev.Data
RUN dotnet build -c Release -o /app

WORKDIR /src/Ambev.Poc.Dev.Domain
RUN dotnet build -c Release -o /app

WORKDIR /src/Ambev.Poc.Dev.Domain.Test
RUN dotnet build -c Release -o /app

WORKDIR /src/AmBev.Poc.Dev.API
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .

ENTRYPOINT ["dotnet", "AmBev.Poc.Dev.API.dll"]