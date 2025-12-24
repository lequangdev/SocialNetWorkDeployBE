# build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy project files first to leverage Docker layer caching
COPY backend/ChatRequestAPI/ReverseProxy/ReverseProxy.csproj ReverseProxy/
COPY backend/ChatRequestAPI/Infrastructure/Infrastructure.csproj Infrastructure/
COPY backend/ChatRequestAPI/DTO/DTO.csproj DTO/
COPY backend/ChatRequestAPI/Domain/Domain.csproj Domain/
COPY backend/ChatRequestAPI/ServiceLayer/ServiceLayer.csproj ServiceLayer/
COPY backend/ChatRequestAPI/DataAccessLayer/DataAccessLayer.csproj DataAccessLayer/
COPY backend/ChatRequestAPI/HostBase/HostBase.csproj HostBase/

# Restore dependencies (includes referenced projects)
RUN dotnet restore ReverseProxy/ReverseProxy.csproj

# Copy the remaining source files
COPY backend/ChatRequestAPI/ReverseProxy/ ReverseProxy/
COPY backend/ChatRequestAPI/Infrastructure/ Infrastructure/
COPY backend/ChatRequestAPI/DTO/ DTO/
COPY backend/ChatRequestAPI/Domain/ Domain/
COPY backend/ChatRequestAPI/ServiceLayer/ ServiceLayer/
COPY backend/ChatRequestAPI/DataAccessLayer/ DataAccessLayer/
COPY backend/ChatRequestAPI/HostBase/ HostBase/

WORKDIR /src/ReverseProxy
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

# runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
ENV ASPNETCORE_URLS=http://0.0.0.0:${PORT}
COPY --from=build /app/publish ./

# optional: expose port (informational)


ENTRYPOINT ["dotnet", "ReverseProxy.dll"]
