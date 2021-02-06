#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Uni.Lectures.API/Uni.Lectures.API.csproj", "Uni.Lectures.API/"]
RUN dotnet restore "Uni.Lectures.API/Uni.Lectures.API.csproj"
COPY . .
WORKDIR "/src/Uni.Lectures.API"
RUN dotnet build "Uni.Lectures.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Uni.Lectures.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Uni.Lectures.API.dll"]