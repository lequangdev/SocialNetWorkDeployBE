# build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy project files first to leverage Docker layer caching
COPY ChatRequestAPI/ReverseProxy/ReverseProxy.csproj ReverseProxy/
COPY ChatRequestAPI/Infrastructure/Infrastructure.csproj Infrastructure/
COPY ChatRequestAPI/DTO/DTO.csproj DTO/
COPY ChatRequestAPI/Domain/Domain.csproj Domain/
COPY ChatRequestAPI/ServiceLayer/ServiceLayer.csproj ServiceLayer/
COPY ChatRequestAPI/DataAccessLayer/DataAccessLayer.csproj DataAccessLayer/
COPY ChatRequestAPI/HostBase/HostBase.csproj HostBase/

# Restore dependencies (includes referenced projects)
RUN dotnet restore ReverseProxy/ReverseProxy.csproj

# Copy the remaining source files
COPY ChatRequestAPI/ReverseProxy/ ReverseProxy/
COPY ChatRequestAPI/Infrastructure/ Infrastructure/
COPY ChatRequestAPI/DTO/ DTO/
COPY ChatRequestAPI/Domain/ Domain/
COPY ChatRequestAPI/ServiceLayer/ ServiceLayer/
COPY ChatRequestAPI/DataAccessLayer/ DataAccessLayer/
COPY ChatRequestAPI/HostBase/ HostBase/

WORKDIR /src/ReverseProxy
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

# runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:80
COPY --from=build /app/publish ./

# optional: expose port (informational)
EXPOSE 80

ENTRYPOINT ["dotnet", "ReverseProxy.dll"]
