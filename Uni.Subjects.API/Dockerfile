#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Uni.Subjects.API/Uni.Subjects.API.csproj", "Uni.Subjects.API/"]
RUN dotnet restore "Uni.Subjects.API/Uni.Subjects.API.csproj"
COPY . .
WORKDIR "/src/Uni.Subjects.API"
RUN dotnet build "Uni.Subjects.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Uni.Subjects.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Uni.Subjects.API.dll"]