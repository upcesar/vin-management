FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["VIN.WebApi/VIN.WebApi.csproj", "VIN.WebApi/"]
COPY ["VIN.Application/VIN.Application.csproj", "VIN.Application/"]
RUN dotnet restore "VIN.WebApi/VIN.WebApi.csproj"
COPY . .
WORKDIR "/src/VIN.WebApi"
RUN dotnet build "VIN.WebApi.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "VIN.WebApi.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "VIN.WebApi.dll"]
