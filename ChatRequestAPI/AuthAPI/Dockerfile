# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src


# Copy tất cả các project trước (để tránh restore lại nhiều lần)
COPY AuthAPI/AuthAPI.csproj AuthAPI/
COPY Infrastructure/Infrastructure.csproj Infrastructure/
COPY DTO/DTO.csproj DTO/
COPY Domain/Domain.csproj Domain/
COPY ServiceLayer/ServiceLayer.csproj ServiceLayer/
COPY DataAccessLayer/DataAccessLayer.csproj DataAccessLayer/
COPY HostBase/HostBase.csproj HostBase/

# Restore chỉ project này
RUN dotnet restore AuthAPI/AuthAPI.csproj

# Copy toàn bộ source code
COPY AuthAPI/ AuthAPI/
COPY Infrastructure/ Infrastructure/
COPY DTO/ DTO/
COPY Domain/ Domain/
COPY ServiceLayer/ ServiceLayer/
COPY DataAccessLayer/ DataAccessLayer/
COPY HostBase/ HostBase/

WORKDIR /src/AuthAPI
RUN dotnet publish -c Release -o /app/publish

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0  AS runtime
WORKDIR /app
ENV ASPNETCORE_URLS=http://0.0.0.0:${PORT}
COPY --from=build /app/publish ./
# optional: expose port (informational)

ENTRYPOINT ["dotnet", "AuthAPI.dll"]
