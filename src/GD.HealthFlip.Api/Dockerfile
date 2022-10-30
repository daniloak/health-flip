#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/GD.HealthFlip.Api/GD.HealthFlip.Api.csproj", "src/GD.HealthFlip.Api/"]
COPY ["src/GD.HealthFlip.Infrastructure/GD.HealthFlip.Infrastructure.csproj", "src/GD.HealthFlip.Infrastructure.EF/"]
COPY ["src/GD.HealthFlip.Application/GD.HealthFlip.Application.csproj", "src/GD.HealthFlip.Application/"]
COPY ["src/GD.HealthFlip.Domain/GD.HealthFlip.Domain.csproj", "src/GD.HealthFlip.Domain/"]
COPY ["src/GD.HealthFlip.SharedKernel/GD.HealthFlip.SharedKernel.csproj", "src/GD.HealthFlip.SharedKernel/"]
RUN dotnet restore "src/GD.HealthFlip.Api/GD.HealthFlip.Api.csproj"
COPY . .
WORKDIR "/src/src/GD.HealthFlip.Api"
RUN dotnet build "GD.HealthFlip.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GD.HealthFlip.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GD.HealthFlip.Api.dll"]