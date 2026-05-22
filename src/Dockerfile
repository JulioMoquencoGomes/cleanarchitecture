FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY ["CleanArchitecture.Api/CleanArchitecture.Api.csproj", "./"]
RUN dotnet restore

COPY . .
RUN dotnet build "CleanArchitecture.Api/CleanArchitecture.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CleanArchitecture.Api/CleanArchitecture.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .

EXPOSE 8080
ENTRYPOINT ["dotnet", "CleanArchitecture.Api.dll"]