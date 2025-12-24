# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy tất cả các project trước (để tránh restore lại nhiều lần)
COPY ChatRequestAPI/ChatAPI/ChatAPI.csproj ChatAPI/
COPY ChatRequestAPI/Infrastructure/Infrastructure.csproj Infrastructure/
COPY ChatRequestAPI/DTO/DTO.csproj DTO/
COPY ChatRequestAPI/Domain/Domain.csproj Domain/
COPY ChatRequestAPI/ServiceLayer/ServiceLayer.csproj ServiceLayer/
COPY ChatRequestAPI/DataAccessLayer/DataAccessLayer.csproj DataAccessLayer/
COPY ChatRequestAPI/HostBase/HostBase.csproj HostBase/

# Restore chỉ project này
RUN dotnet restore ChatAPI/ChatAPI.csproj

# Copy source code
COPY ChatRequestAPI/ChatAPI/ ChatAPI/
COPY ChatRequestAPI/Infrastructure/ Infrastructure/
COPY ChatRequestAPI/DTO/ DTO/
COPY ChatRequestAPI/Domain/ Domain/
COPY ChatRequestAPI/ServiceLayer/ ServiceLayer/
COPY ChatRequestAPI/DataAccessLayer/ DataAccessLayer/
COPY ChatRequestAPI/HostBase/ HostBase/

WORKDIR /src/ChatAPI
RUN dotnet publish -c Release -o /app/publish 

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
ENV ASPNETCORE_URLS=http://0.0.0.0:${PORT}
COPY --from=build /app/publish ./
# optional: expose port (informational)
ENTRYPOINT ["dotnet", "ChatAPI.dll"]
