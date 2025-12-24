# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src


# Copy tất cả các project trước (để tránh restore lại nhiều lần)
COPY backend/ChatRequestAPI/AuthAPI/AuthAPI.csproj AuthAPI/
COPY backend/ChatRequestAPI/Infrastructure/Infrastructure.csproj Infrastructure/
COPY backend/ChatRequestAPI/DTO/DTO.csproj DTO/
COPY backend/ChatRequestAPI/Domain/Domain.csproj Domain/
COPY backend/ChatRequestAPI/ServiceLayer/ServiceLayer.csproj ServiceLayer/
COPY backend/ChatRequestAPI/DataAccessLayer/DataAccessLayer.csproj DataAccessLayer/
COPY backend/ChatRequestAPI/HostBase/HostBase.csproj HostBase/

# Restore chỉ project này
RUN dotnet restore AuthAPI/AuthAPI.csproj

# Copy toàn bộ source code
COPY backend/ChatRequestAPI/AuthAPI/ AuthAPI/
COPY backend/ChatRequestAPI/Infrastructure/ Infrastructure/
COPY backend/ChatRequestAPI/DTO/ DTO/
COPY backend/ChatRequestAPI/Domain/ Domain/
COPY backend/ChatRequestAPI/ServiceLayer/ ServiceLayer/
COPY backend/ChatRequestAPI/DataAccessLayer/ DataAccessLayer/
COPY backend/ChatRequestAPI/HostBase/ HostBase/

WORKDIR /src/AuthAPI
RUN dotnet publish -c Release -o /app/publish

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0  AS runtime
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:80
COPY --from=build /app/publish ./
# optional: expose port (informational)
EXPOSE 80
ENTRYPOINT ["dotnet", "AuthAPI.dll"]
