#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Quakes.Api/Quakes.Api.csproj", "Quakes.Api/"]
RUN dotnet restore "Quakes.Api/Quakes.Api.csproj"
COPY . .
WORKDIR "/src/Quakes.Api"
RUN dotnet build "Quakes.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Quakes.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Quakes.Api.dll"]