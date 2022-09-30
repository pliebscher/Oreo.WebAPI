  FROM mcr.microsoft.com/dotnet/aspnet:6.0
  COPY bin/Release/netcoreapp3.1/*.* /App
  WORKDIR /App
  ENTRYPOINT ["Oreo.WebAPI.Utils", "Oreo.WebAPI.Utils.dll"]