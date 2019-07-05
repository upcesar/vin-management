FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["VIN-Management/VIN-Management.csproj", "VIN-Management/"]
RUN dotnet restore "VIN-Management/VIN-Management.csproj"
COPY . .
WORKDIR "/src/VIN-Management"
RUN dotnet build "VIN-Management.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "VIN-Management.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "VIN-Management.dll"]