# -----------------------------------------------------------------------------------------
# Build from solution directory (Oreo.WebAPI.Utils)
# docker build -f Oreo.WebAPI.Utils\Dockerfile --force-rm -t pliebscher/oreowebapiutils .
# -----------------------------------------------------------------------------------------
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-alpine
COPY ["Oreo.WebAPI.Utils/bin/Release/netcoreapp3.1", "/App"]
WORKDIR /App
EXPOSE 5000 # Documentation
ENTRYPOINT ["dotnet", "Oreo.WebAPI.Utils.dll"]