# -----------------------------------------------------------------------------------------
# Build from solution directory (Oreo.WebAPI.OpenWeather)
# BUILD	: docker build -f Oreo.WebAPI.OpenWeather\Dockerfile --force-rm -t {namespace/image name} .
# RUN	: docker run -p 80:80 -e OPENWEATHER__APIKEY={your OpenWeather api key} {namespace/image name}
# -----------------------------------------------------------------------------------------
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-alpine
COPY ["Oreo.WebAPI.OpenWeather/bin/Debug/netcoreapp3.1", "/App"]
WORKDIR /App
EXPOSE 80
ENTRYPOINT ["dotnet", "Oreo.WebAPI.OpenWeather.dll"]