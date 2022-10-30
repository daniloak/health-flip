#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Directory.Packages.props", ""]
COPY ["src/GD.HealthFlip.Api/GD.HealthFlip.Api.csproj", "GD.HealthFlip.Api/"]
COPY ["src/GD.HealthFlip.Infrastructure/GD.HealthFlip.Infrastructure.csproj", "GD.HealthFlip.Infrastructure.EF/"]
COPY ["src/GD.HealthFlip.Application/GD.HealthFlip.Application.csproj", "GD.HealthFlip.Application/"]
COPY ["src/GD.HealthFlip.Core/GD.HealthFlip.Core.csproj", "GD.HealthFlip.Core/"]
COPY ["src/GD.HealthFlip.SharedKernel/GD.HealthFlip.SharedKernel.csproj", "GD.HealthFlip.SharedKernel/"]
RUN dotnet restore "GD.HealthFlip.Api/GD.HealthFlip.Api.csproj"
COPY . .
WORKDIR "/src/GD.HealthFlip.Api"
RUN dotnet build "GD.HealthFlip.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GD.HealthFlip.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GD.HealthFlip.Api.dll"]