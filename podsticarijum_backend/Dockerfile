#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["./podsticarijum_backend.Api/podsticarijum_backend.Api.csproj", "./podsticarijum_backend.Api/"]
COPY ["./podsticarijum_backend.Application/podsticarijum_backend.Application.csproj", "./podsticarijum_backend.Application/"]
COPY ["./podsticarijum_backend.Repository/podsticarijum_backend.Repository.csproj", "./podsticarijum_backend.Repository/"]
COPY ["./podsticarijum_backend.Domain/podsticarijum_backend.Domain.csproj", "./podsticarijum_backend.Domain/"]
RUN dotnet restore "./podsticarijum_backend.Api/podsticarijum_backend.Api.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "./podsticarijum_backend.Api/podsticarijum_backend.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./podsticarijum_backend.Api/podsticarijum_backend.Api.csproj" -c Debug -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "podsticarijum_backend.Api.dll"]
