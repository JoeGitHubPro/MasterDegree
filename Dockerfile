FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["app.csproj", "./"]
RUN dotnet restore "./MasterDegree.csproj"
COPY . .
RUN dotnet build "MasterDegree.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "MasterDegree.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "app.dll"]