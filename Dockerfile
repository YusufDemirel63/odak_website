# Build asamasinin baslatilmasi (SDK 10.0 imajini indirir)
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Proje dosyasini kopyala ve bagimliliklari indir (Restore)
COPY ["OdakMVC.csproj", "./"]
RUN dotnet restore "OdakMVC.csproj"

# Tum dosyalari kopyalayip yayin versiyonunu derle
COPY . .
RUN dotnet publish "OdakMVC.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Calistirma (Runtime 10.0 imajina gecis)
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Uygulamayi disariya acmak icin portu bildir
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "OdakMVC.dll"]
