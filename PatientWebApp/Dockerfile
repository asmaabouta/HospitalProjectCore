# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/sdk:3.1


WORKDIR /app

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:3.1

COPY out .

ENTRYPOINT ["dotnet","PatientWebApp.dll"]