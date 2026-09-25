FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore src/DrinkOrderingSystem.API/DrinkOrderingSystem.API.csproj
RUN dotnet publish src/DrinkOrderingSystem.API/DrinkOrderingSystem.API.csproj -c Release -o /app/publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "DrinkOrderingSystem.API.dll"]
