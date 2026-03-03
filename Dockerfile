# Build stage
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Kopiuj projekt
COPY ["aspnetVol1/aspnetVol1.csproj", "aspnetVol1/"]
RUN dotnet restore "aspnetVol1/aspnetVol1.csproj"


COPY . .
WORKDIR "/src/aspnetVol1"
RUN dotnet build "aspnetVol1.csproj" -c Release -o /app/build

# Publish stage
FROM build AS publish
RUN dotnet publish "aspnetVol1.csproj" -c Release -o /app/publish

# ...existing code...

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app

COPY --from=publish /app/publish .

EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Development

ENTRYPOINT ["dotnet", "aspnetVol1.dll"]

