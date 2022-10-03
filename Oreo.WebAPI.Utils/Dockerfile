
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-alpine
COPY ["Oreo.WebAPI.Utils/bin/Release/netcoreapp3.1", "/App"]
WORKDIR /App
ENTRYPOINT ["dotnet", "Oreo.WebAPI.Utils.dll"]