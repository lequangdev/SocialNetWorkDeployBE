FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy toàn bộ source
COPY . .

# Restore & publish đúng service
RUN dotnet restore ReverseProxy/ReverseProxy.csproj
RUN dotnet publish ReverseProxy/ReverseProxy.csproj -c Release -o /app/publish


FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
ENV ASPNETCORE_URLS=http://0.0.0.0:${PORT}

COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "ReverseProxy.dll"]
