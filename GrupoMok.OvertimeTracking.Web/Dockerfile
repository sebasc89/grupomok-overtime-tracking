#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["GrupoMok.OvertimeTracking.Web/GrupoMok.OvertimeTracking.Web.csproj", "GrupoMok.OvertimeTracking.Web/"]
RUN dotnet restore "GrupoMok.OvertimeTracking.Web/GrupoMok.OvertimeTracking.Web.csproj"
COPY . .
WORKDIR "/src/GrupoMok.OvertimeTracking.Web"
RUN dotnet build "GrupoMok.OvertimeTracking.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GrupoMok.OvertimeTracking.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "GrupoMok.OvertimeTracking.Web.dll"]