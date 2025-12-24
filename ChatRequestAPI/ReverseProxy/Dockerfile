# build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy project files first to leverage Docker layer caching
COPY ReverseProxy/ReverseProxy.csproj ReverseProxy/
COPY Infrastructure/Infrastructure.csproj Infrastructure/
COPY DTO/DTO.csproj DTO/
COPY Domain/Domain.csproj Domain/
COPY ServiceLayer/ServiceLayer.csproj ServiceLayer/
COPY DataAccessLayer/DataAccessLayer.csproj DataAccessLayer/
COPY HostBase/HostBase.csproj HostBase/

# Restore dependencies (includes referenced projects)
RUN dotnet restore ReverseProxy/ReverseProxy.csproj

# Copy the remaining source files
COPY ReverseProxy/ ReverseProxy/
COPY Infrastructure/ Infrastructure/
COPY DTO/ DTO/
COPY Domain/ Domain/
COPY ServiceLayer/ ServiceLayer/
COPY DataAccessLayer/ DataAccessLayer/
COPY HostBase/ HostBase/

WORKDIR /src/ReverseProxy
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

# runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
ENV ASPNETCORE_URLS=http://0.0.0.0:${PORT}
COPY --from=build /app/publish ./

# optional: expose port (informational)


ENTRYPOINT ["dotnet", "ReverseProxy.dll"]
