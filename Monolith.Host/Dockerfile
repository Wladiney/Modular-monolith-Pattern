#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Monolith.Host/Monolith.Host.csproj", "Monolith.Host/"]
COPY ["Monolith.ModuleB/Monolith.ModuleB.csproj", "Monolith.ModuleB/"]
COPY ["Monolith.ModuleA.Shared/Monolith.ModuleA.Shared.csproj", "Monolith.ModuleA.Shared/"]
COPY ["Monolith.Shared/Monolith.Shared.csproj", "Monolith.Shared/"]
COPY ["Monolith.ModuleA/Monolith.ModuleA.csproj", "Monolith.ModuleA/"]
RUN dotnet restore "Monolith.Host/Monolith.Host.csproj"
COPY . .
WORKDIR "/src/Monolith.Host"
RUN dotnet build "Monolith.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Monolith.Host.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Monolith.Host.dll"]